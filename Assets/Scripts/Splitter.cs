using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    public GameObject enemy;
    
    public void spawnBaddies() {
        for(int i = 1; i < 5; i++){
            enemy.gameObject.GetComponent<FollowTarget>().target = GameObject.Find("Player").transform;
            enemy.gameObject.GetComponent<FollowTarget>().enabled = false;
            enemy.gameObject.GetComponent<Wander>().enabled = true;
            Instantiate(enemy, transform.position, Quaternion.identity);
            enemy.gameObject.GetComponent<Wander>().enabled = false;
            enemy.gameObject.GetComponent<FollowTarget>().enabled = true;
        }
        
    }
}
