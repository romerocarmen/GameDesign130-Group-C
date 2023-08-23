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
            spawnRateRainbow += spawnDeltaAdvanced;
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
        
        for(int j = 0; j < quantity; j++){
            Instantiate(enemy, SetSpawnPosition(position), Quaternion.identity);
        }
    }

    // void SetSpawnRate()
    // {
    //     // setting the spawn rate
    //     if (LevelCounter.levelValue == 1)
    //     {
    //         spawnRateBasic = 1f;
    //         spawnRateRainbow = 0f;
    //         spawnRateSplitter = 0f;
    //     }
    //     else if (LevelCounter.levelValue == 2)
    //     {
    //         spawnRateBasic = 1.5f;
    //         spawnRateRainbow = 0.1f;
    //         spawnRateSplitter = 0.1f;
    //     }
    //     else if (LevelCounter.levelValue == 3)
    //     {
    //         spawnRateBasic = 2f;
    //         spawnRateRainbow = 0.2f;
    //         spawnRateSplitter = 0.2f;
    //     }
    //     else if (LevelCounter.levelValue == 4)
    //     {
    //         spawnRateBasic = 2.5f;
    //         spawnRateRainbow = 0.3f;
    //         spawnRateSplitter = 0.3f;
    //     }
    //     else if (LevelCounter.levelValue == 5)
    //     {
    //         spawnRateBasic = 0f;
    //         spawnRateRainbow = 0f;
    //         spawnRateSplitter = 0f;
    //     }
    //     else if (LevelCounter.levelValue == 6)
    //     {
    //         spawnRateBasic = 3f;
    //         spawnRateRainbow = 0.5f;
    //         spawnRateSplitter = 0.5f;
    //     }
    //     else if (LevelCounter.levelValue == 7)
    //     {
    //         spawnRateBasic = 3.5f;
    //         spawnRateRainbow = 0.6f;
    //         spawnRateSplitter = 0.6f;
    //     }
    //     else if (LevelCounter.levelValue == 8)
    //     {
    //         spawnRateBasic = 4f;
    //         spawnRateRainbow = 0.7f;
    //         spawnRateSplitter = 0.7f;
    //     }
    //     else if (LevelCounter.levelValue == 9)
    //     {
    //         spawnRateBasic = 4.5f;
    //         spawnRateRainbow = 0.8f;
    //         spawnRateSplitter = 0.8f;
    //     }
    //     else if (LevelCounter.levelValue == 10)
    //     {
    //         spawnRateBasic = 5f;
    //         spawnRateRainbow = 0.9f;
    //         spawnRateSplitter = 0.9f;
    //     }
    // }

}