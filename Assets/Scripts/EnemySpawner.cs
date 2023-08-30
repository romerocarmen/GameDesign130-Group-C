using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject redEnemy;
    public GameObject greenEnemy;
    public GameObject blueEnemy;
    public GameObject rainbowEnemy;
    public GameObject redSplitter;
    public GameObject greenSplitter;
    public GameObject blueSplitter;
    public GameObject rainbowSplitter;
    

    // timer
    private float basicTimer = 0;
    // timer for splitter enemies
    private float splitterTimer = 0;
    // timer for rainbow enemies
    private float rainbowTimer = 0;

    //private int waveNumber = 0;
    public Transform target;
    // amount of times basic enemy spawns per second
    public float spawnRateBasic = 1f;

    // amount of times splitter enemy spawns per second
    public float spawnRateSplitter = .5f;

    // amount of times rainbow enemy spawns per second
    public float spawnRateRainbow = .5f;

    private int enemyColor; // 1 is red, 2 is green, 3 is blue
    private int spawnWall; // 0 left, 1 top, 2 right, 3 bottom
    public float spawnDelta = 0.00005f;
    public float spawnDeltaAdvanced = 0.00005f;

    public float basicEnemySpeed = 5;
    public float splitterSpeed = 5;

    public int minEnemyCount = 1;
    public int maxEnemyCount = 1;

    private void Start(){
        redEnemy.GetComponent<ColorSet>().color = new Color(1,0,0);
        greenEnemy.GetComponent<ColorSet>().color = new Color(0,1,0);
        blueEnemy.GetComponent<ColorSet>().color = new Color(0,1,1);
        redSplitter.GetComponent<ColorSet>().color = new Color(1,0,0);
        greenSplitter.GetComponent<ColorSet>().color = new Color(0,1,0);
        blueSplitter.GetComponent<ColorSet>().color = new Color(0,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        //SetSpawnRate();
    }

    // This spawns a random amount of enemies every 5 seconds
    void FixedUpdate()
    {
        if(spawnRateBasic != 0){
            spawnRateBasic += spawnDelta;
            basicTimer += Time.deltaTime;
            if(basicTimer > 1/spawnRateBasic){
                basicEnemySpawner();
            }
        }
        
        if(spawnRateSplitter != 0){
            splitterTimer += Time.deltaTime;
            spawnRateSplitter += spawnDeltaAdvanced;
            if(splitterTimer > 1/spawnRateSplitter){
                splitterEnemySpawner();
            }
        }
        
        if(spawnRateRainbow != 0){
            // spawnRateRainbow += spawnDeltaAdvanced;
            rainbowTimer += Time.deltaTime;
            if(rainbowTimer > 1/spawnRateRainbow){
                rainbowEnemySpawner();
            }
        }
    }

    private void basicEnemySpawner(){
        basicTimer = 0;
        enemyColor = Random.Range(1,4);
        spawnWall = Random.Range(0,4);
        int enemyNumber = Random.Range(minEnemyCount, maxEnemyCount + 1);
        switch(enemyColor){
            case 1: //Red Enemy spawn
                SpawnEnemies(enemyNumber, spawnWall, redEnemy, basicEnemySpeed);
                break;
            case 2: //Green Enemy spawn
                SpawnEnemies(enemyNumber, spawnWall, greenEnemy, basicEnemySpeed);
                break;
            case 3: //Blue Enemy spawn
                SpawnEnemies(enemyNumber, spawnWall, blueEnemy, basicEnemySpeed);
                break;
            default:
                //This is if the die rolls 4, in which nothing spawns
                break;
        }
    }

    private void rainbowEnemySpawner(){
        rainbowTimer = 0;
        spawnWall = Random.Range(0,4);
        int enemyNumber = Random.Range(minEnemyCount, maxEnemyCount + 1);
        SpawnEnemies(enemyNumber, spawnWall, rainbowEnemy, basicEnemySpeed);
    }

    private void splitterEnemySpawner(){

        splitterTimer = 0;
        enemyColor = Random.Range(1,5);
        spawnWall = Random.Range(0,4);

        switch(enemyColor){
            case 1: //Red Enemy spawn
                SpawnEnemies(1, spawnWall, redSplitter, splitterSpeed);
                break;
            case 2: //Green Enemy spawn
                SpawnEnemies(1, spawnWall, greenSplitter, splitterSpeed);
                break;
            case 3: //Blue Enemy spawn
                SpawnEnemies(1, spawnWall, blueSplitter, splitterSpeed);
                break;
            case 4: //rainbow Enemy spawn
                SpawnEnemies(1, spawnWall, rainbowSplitter, splitterSpeed);
                break;
            default:
                //This is if the die rolls 4, in which nothing spawns
                break;
        }
    }

    float RollSpawnDie(){
        return Random.Range(1,5);
    }

    public Vector2 SetSpawnPosition(int spot){
        Vector2 spawnPosition = new Vector2(0,0);
        switch(spot){
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

    public void SpawnEnemies(int quantity, int position, GameObject enemy, float speed){
        enemy.gameObject.GetComponent<FollowTarget>().enabled = true;
        enemy.gameObject.GetComponent<FollowTarget>().target = target;
        enemy.gameObject.GetComponent<FollowTarget>().speed = speed;
        enemy.gameObject.GetComponent<FollowTarget>().splitEnemy = false;
        enemy.gameObject.GetComponent<EnemySpawnChecker>().timer = 0;
        enemy.gameObject.GetComponent<EnemySpawnChecker>().onScreen = false;
        
        for(int j = 0; j < quantity; j++){
            Instantiate(enemy, SetSpawnPosition(position), Quaternion.identity);
        }
    }

}