using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SASpawner : MonoBehaviour
{
    public GameObject redStageAttack;
    public GameObject greenStageAttack;
    public GameObject blueStageAttack;
    private int dangerWall = 1;
    private float timer = 0;

    public float spawnRate = .5f;
    public float spawnDelta = 0.00005f;

    public float multiAttackChance = 1f;
    public int minMultiCount = 1;
    public int maxMultiCount = 2;
    public int multiAttackNumber = 1;
    public bool targetPlayer = false;

    private int lastSpawnWall = 1;

    //variables for each stage attack prefab spawn
    public Vector3 scaleChange = new Vector3(1f, 0f, 0f);
    public float ghostBoxTime = 3;
    public float width = 15;


    [SerializeField] public AudioClip theClip; 
    [SerializeField] private AudioSource stageAttackAudio;
    [SerializeField] private float volume = 0.5f; 

    private void Start()
    {
        stageAttackAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    //Stage Attacks happen every 10 seconds
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        spawnRate += spawnDelta;
        if(timer > 1/spawnRate){
            if(Random.value < multiAttackChance){
                multiAttackNumber = Random.Range(minMultiCount, maxMultiCount+1);
                Debug.Log("MULTI ATTACK! Number is " + multiAttackNumber);
            }
            else
            {
                Debug.Log("Only one stage attack");
            }
            stageAttackAudio.PlayOneShot(theClip, volume);
            timer = 0;

            for(int i = 0; i < multiAttackNumber; i++){
                dangerWall = Random.Range(1,4);
                while(dangerWall == lastSpawnWall){
                    dangerWall = Random.Range(1,4);
                }
                
                switch(Random.Range(1,4)){
                    case 1:
                        SpawnAttack(redStageAttack);
                        break;
                    case 2:
                        SpawnAttack(greenStageAttack);
                        break;
                    case 3:
                        SpawnAttack(blueStageAttack);
                        break;
                }
                lastSpawnWall = dangerWall;
            }
            multiAttackNumber = 1;
        }
    }

    Vector2 SetSpawnPosition(){
        Vector2 spawnPosition = new Vector2(0,0);
        switch (dangerWall) {
            case 0: //Left
                if (targetPlayer == true)
                {
                    spawnPosition = new Vector2(-50, GameObject.Find("Player").transform.position.y);
                } else
                {
                    spawnPosition = new Vector2(-50, Random.Range(-15, 15));
                }
                break;
            case 1: //Top
                if (targetPlayer == true)
                {
                    spawnPosition = new Vector2(GameObject.Find("Player").transform.position.x, 30);
                } else
                {
                    spawnPosition = new Vector2(Random.Range(-35, 35), 30);
                }
                break;
            case 2: //Right
                if (targetPlayer == true)
                {
                    spawnPosition = new Vector2(50, GameObject.Find("Player").transform.position.y);
                } else
                {
                    spawnPosition = new Vector2(50, Random.Range(-15, 15));
                }
                break;
            case 3: //Bottom
                if (targetPlayer == true)
                {
                    spawnPosition = new Vector2(GameObject.Find("Player").transform.position.x, -30);
                } else
                {
                    spawnPosition = new Vector2(Random.Range(-35, 35), -30);
                }
                break;
            default: //Should never happen
                break;
        }
        return spawnPosition;
    }

    void SpawnAttack(GameObject attack){
        attack.gameObject.GetComponent<StageAttackHandler>().scaleChange = scaleChange;
        attack.gameObject.GetComponent<StageAttackHandler>().ghostBoxTime = ghostBoxTime;
        attack.gameObject.GetComponent<StageAttackHandler>().width = width;

        if (dangerWall == 0 || dangerWall == 2){ //Left or Right Wall
            Instantiate(attack, SetSpawnPosition(), Quaternion.identity);
        } else {
            Instantiate(attack, SetSpawnPosition(), Quaternion.Euler(new Vector3(0,0,90)));
        }
    }
}
