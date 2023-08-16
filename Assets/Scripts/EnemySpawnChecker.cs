using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnChecker : MonoBehaviour
{
    public GameObject enemy;

    public float timer = 0;
    private bool onScreen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "NoEnemySpawnBubble" && (timer < 0.5 || !onScreen)){
            GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().SpawnEnemies(1, Random.Range(0, 3), enemy, enemy.GetComponent<FollowTarget>().speed);
            Destroy(gameObject);
        }
        if(other.name == "TargetSwitcher"){
            onScreen = true;
        }
    }
}
