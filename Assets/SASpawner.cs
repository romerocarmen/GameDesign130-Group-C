using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SASpawner : MonoBehaviour
{
    public GameObject redStageAttack;
    public GameObject greenStageAttack;
    public GameObject blueStageAttack;
    private int dangerWall;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //Stage Attacks happen every 10 seconds
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        
        if(timer > 10){
            timer = 0;
            //Set wall that the attack is coming from
            dangerWall = Random.Range(0,4);
            switch(RollSpawnDie()){
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
        }
    }

    Vector2 SetSpawnPosition(){
        Vector2 spawnPosition = new Vector2(0,0);
        switch(dangerWall){
            case 0: //Left
                spawnPosition = new Vector2(Random.Range(-50, -45), Random.Range(-20, 20));
                break; 
            case 1: //Top
                spawnPosition = new Vector2(Random.Range(-40, 40), Random.Range(25, 30));
                break;
            case 2: //Right
                spawnPosition = new Vector2(Random.Range(45, 50), Random.Range(-20, 20));
                break;
            case 3: //Bottom
                spawnPosition = new Vector2(Random.Range(-40, 40), Random.Range(-30, -25));
                break;
            default: //Should never happen
                break;
        }
        return spawnPosition;
    }

    float RollSpawnDie(){
        return Random.Range(1,4);
    }

    void SpawnAttack(GameObject attack){
        if(dangerWall == 0 || dangerWall == 2){ //Left or Right Wall
           Instantiate(attack, SetSpawnPosition(), Quaternion.identity);
        } else {
            Instantiate(attack, SetSpawnPosition(), Quaternion.Euler(new Vector3(0,0,90)));
        }
    }
}
