using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public int level = LevelCounter.levelValue;

    public float enemyBasicSpawnRate = EnemySpawner.spawnRateBasic;
    public float enemySplitterSpawnRate = EnemySpawner.spawnRateSplitter;
    public float enemyRainbowSpawnRate = EnemySpawner.spawnRateRainbow;

    // enemy speed is through follow target

    // Update is called once per frame
    void Update()
    {
        if (level == 1)
        {
            // enemy setters
            enemyBasicSpawnRate = 1f;
            enemyRainbowSpawnRate = 0f;
            enemySplitterSpawnRate = 0f;

            // speed here.. etc

            // stage attack setters


            // safe zone setters


            // player setters
            // this one is the weapon one

        }
        else if (level == 2)
        {
            // enemy setters
            enemyBasicSpawnRate = 1.5f;
            enemyRainbowSpawnRate = 0.1f;
            enemySplitterSpawnRate = 0.1f;
        }
        else if (level == 3)
        {
            // enemy setters
            enemyBasicSpawnRate = 2f;
            enemyRainbowSpawnRate = 0.2f;
            enemySplitterSpawnRate = 0.2f;
        }
        else if (level == 4)
        {
            // enemy setters
            enemyBasicSpawnRate = 2.5f;
            enemyRainbowSpawnRate = 0.3f;
            enemySplitterSpawnRate = 0.3f;
        }
        else if (level == 5)
        {
            // enemy setters
            enemyBasicSpawnRate = 0f;
            enemyRainbowSpawnRate = 0f;
            enemySplitterSpawnRate = 0f;
        }
        else if (level == 6)
        {
            // enemy setters
            enemyBasicSpawnRate = 3f;
            enemyRainbowSpawnRate = 0.5f;
            enemySplitterSpawnRate = 0.5f;
        }
        else if (level == 7)
        {
            // enemy setters
            enemyBasicSpawnRate = 3.5f;
            enemyRainbowSpawnRate = 0.6f;
            enemySplitterSpawnRate = 0.6f;
        }
        else if (level == 8)
        {
            // enemy setters
            enemyBasicSpawnRate = 4f;
            enemyRainbowSpawnRate = 0.7f;
            enemySplitterSpawnRate = 0.7f;
        }
        else if (level == 9)
        {
            // enemy setters
            enemyBasicSpawnRate = 4.5f;
            enemyRainbowSpawnRate = 0.8f;
            enemySplitterSpawnRate = 0.8f;
        }
        else if (level == 10)
        {
            // enemy setters
            enemyBasicSpawnRate = 5f;
            enemyRainbowSpawnRate = 0.9f;
            enemySplitterSpawnRate = 0.9f;
        }
    }
}
