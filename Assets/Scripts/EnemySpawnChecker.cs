using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnChecker : MonoBehaviour
{
    public GameObject enemy;

    private float timer = 0;
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
        if(other.name == "NoEnemySpawnBubble" && timer < 0.5){
            GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().SpawnEnemies(1, Random.Range(0, 3), enemy);
            Destroy(gameObject);
        }
    }
}
