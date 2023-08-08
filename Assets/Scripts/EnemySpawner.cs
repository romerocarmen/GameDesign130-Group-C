using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject redEnemy;
    public GameObject greenEnemy;
    public GameObject blueEnemy;

    private float timer = 5;
    private int waveNumber = 0;
    public Transform target;

    // Update is called once per frame
    // This spawns a random amount of enemies every 5 seconds
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        //Every 5 seconds
        if(timer > 3){
            // Set timer back to 0
            timer = 0;
            waveNumber += 1;
            //"roll" to see if enemies spawn for each side of the arena
            //Loop runs 4 times, once for each side
            for(int i = 0; i<4; i++){
                //switch statement determines what is spawning at this side
                // 1/4 of a chance for each enemy color, 1/4 chance of nothing
                switch(RollSpawnDie()){
                    case 1: //5-10 Red Enemies spawn
                        SpawnEnemies(Random.Range(0,waveNumber) + 1, i, redEnemy);//Random.Range(5,10)
                        break;
                    case 2: //5-10 Green Enemies spawn
                        SpawnEnemies(Random.Range(0,waveNumber) + 1, i, greenEnemy);//Random.Range(5,10)
                        break;
                    case 3: //5-10 Blue Enemies spawn
                        SpawnEnemies(Random.Range(0,waveNumber) + 1, i, blueEnemy);//Random.Range(5,10)
                        break;
                    default:
                        //This is if the die rolls 4, in which nothing spawns
                        break;
                }
            }
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
        for(int j = 0; j < quantity; j++){
            Instantiate(enemy, SetSpawnPosition(position), Quaternion.identity);
            enemy.gameObject.GetComponent<FollowTarget>().target = target;
            enemy.gameObject.GetComponent<Wander>().enabled = false;
        }
    }
}