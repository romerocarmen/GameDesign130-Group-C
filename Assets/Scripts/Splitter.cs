using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    public GameObject enemy;
    
    public void spawnBaddies() {
        string[] walls = {"TopWall", "BottomWall", "RightWall", "LeftWall"};

        for(int i = 0; i < 4; i++){
            enemy.gameObject.GetComponent<FollowTarget>().splitEnemy = true;
            //enemy.gameObject.GetComponent<FollowTarget>().target = GameObject.Find("Player").transform;
            enemy.gameObject.GetComponent<EnemySpawnChecker>().timer = 1;
            enemy.gameObject.GetComponent<EnemySpawnChecker>().onScreen = true;
            //enemy.gameObject.GetComponent<Wander>().enabled = true;
            enemy.gameObject.GetComponent<FollowTarget>().target = GameObject.Find(walls[i]).transform;
            Instantiate(enemy, transform.position, Quaternion.identity);
            //enemy.gameObject.GetComponent<Wander>().enabled = false;
            // enemy.gameObject.GetComponent<FollowTarget>().enabled = true;
        }
        
    }
}
