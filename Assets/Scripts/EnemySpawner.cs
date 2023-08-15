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
        enemyColor = 3;
        spawnWall = Random.Range(0,4);

        switch(enemyColor){
            case 1: //Red Enemy spawn
                SpawnEnemies(1, spawnWall, redEnemy);
                break;
            case 2: //Green Enemy spawn
                SpawnEnemies(1, spawnWall, greenEnemy);
                break;
            case 3: //Blue Enemy spawn
                SpawnEnemies(1, spawnWall, blueEnemy);
                break;
            default:
                //This is if the die rolls 4, in which nothing spawns
                break;
        }
    }

    private void rainbowEnemySpawner(){
        rainbowTimer = 0;
        spawnWall = Random.Range(0,4);
        SpawnEnemies(1, spawnWall, rainbowEnemy);
    }

    private void splitterEnemySpawner(){
        Debug.Log("Spawning a splitter now!");
        splitterTimer = 0;
        enemyColor = Random.Range(1,5);
        spawnWall = Random.Range(0,4);

        switch(enemyColor){
            case 1: //Red Enemy spawn
                SpawnEnemies(1, spawnWall, redSplitter);
                break;
            case 2: //Green Enemy spawn
                SpawnEnemies(1, spawnWall, greenSplitter);
                break;
            case 3: //Blue Enemy spawn
                SpawnEnemies(1, spawnWall, blueSplitter);
                break;
            case 4: //rainbow Enemy spawn
                SpawnEnemies(1, spawnWall, rainbowSplitter);
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

    public void SpawnEnemies(int quantity, int position, GameObject enemy){
        enemy.gameObject.GetComponent<FollowTarget>().enabled = true;
        enemy.gameObject.GetComponent<FollowTarget>().target = target;
        Instantiate(enemy, SetSpawnPosition(position), Quaternion.identity);
        // for(int j = 0; j < quantity; j++){
        //     enemy.gameObject.GetComponent<FollowTarget>().target = target;
        //     Instantiate(enemy, SetSpawnPosition(position), Quaternion.identity);
        // }
    }
}