using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public int level = LevelCounter.levelValue;

    // public float enemyBasicSpawnRate = EnemySpawner.spawnRateBasic;
    // public float enemySplitterSpawnRate = EnemySpawner.spawnRateSplitter;
    // public float enemyRainbowSpawnRate = EnemySpawner.spawnRateRainbow;

    public float playerSpeed = 3f;
    public float playerFireRate = 10f;
    //public int playerWeapon = 1;
    public float basicEnemySpeed = 10f;
    public float splitterSpeed = 5f;
    public float basicEnemySpawnRate = 1f;
    public float basicEnemySpawnDelta = 0.0005f;
    public float splitterSpawnRate = 0f;
    public float rainbowSpawnRate = 0f;
    public float advancedSpawnDelta = 0f;
    public float saSpawnRate = 0f;
    public float saSpawnDelta = 0f;
    public float saWidth = 0f;
    public float saGhostBoxTiming = 0f;
    public Vector3 saScaleChange = Vector3.zero;
    public float szMaxDiameter = 20f;
    public float szPatrolSpeed = 0f;
    public float szShrinkRate = 1f;
    public float szGrowthRate = 1f;

    private bool valuesChanged = false;
    
    void Start()
    {
        // set the game values for lvl 1
        changeGameValues();
    }

    // enemy speed is through follow target

    // Update is called once per frame
    void Update()
    {
        if(level != LevelCounter.levelValue){
            level = LevelCounter.levelValue;
            valuesChanged = false;
        }
        
        if(!valuesChanged){
            if (level == 2)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 2; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 1f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;

                changeGameValues();
                valuesChanged = true;
            }
            else if (level == 3)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 3; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 2f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;
            }
            else if (level == 4)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 4; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 3f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 15f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;
            }
            else if (level == 5)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 5; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 10f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 15f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;
            }
            else if (level == 6)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 6; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 4f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 15f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;
            }
            else if (level == 7)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 7; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 5f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 15f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;
            }
            else if (level == 8)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 8; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 6f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 15f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;
            }
            else if (level == 9)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 9; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 7f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 15f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;
            }
            else if (level == 10)
            {
                // player setters
                playerSpeed = 3f;
                playerFireRate = 10f;
                // playerWeapon = 10; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 1f;
                basicEnemySpawnRate = 0f;
                splitterSpawnRate = 0f;
                rainbowSpawnRate = 0f;

                // stage attack setters
                saSpawnRate = 8f;
                saWidth = 15f;
                saGhostBoxTiming = 1f;


                // safe zone setters
                szMaxDiameter = 15f;
                szPatrolSpeed = 0f;
                szShrinkRate = 1f;
                szGrowthRate = 1f;
            }
            changeGameValues();
            valuesChanged = true;
        }
        
    }

    void changeGameValues(){
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().basicEnemySpeed = basicEnemySpeed;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().spawnRateBasic = basicEnemySpawnRate;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().spawnDelta = basicEnemySpawnDelta;
        
        // splitter and rainbow enemies
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().splitterSpeed = splitterSpeed;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().spawnRateSplitter = splitterSpawnRate;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().spawnDeltaAdvanced = advancedSpawnDelta;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().spawnRateRainbow = rainbowSpawnRate;

        // change the spawn rate, width, ghost box timer, scale change, and spawn delta of stage attacks
        GameObject.Find("ArenaMaster").GetComponent<SASpawner>().spawnRate = saSpawnRate;
        GameObject.Find("ArenaMaster").GetComponent<SASpawner>().spawnDelta = saSpawnDelta;
        GameObject.Find("ArenaMaster").GetComponent<SASpawner>().width = saWidth;
        GameObject.Find("ArenaMaster").GetComponent<SASpawner>().ghostBoxTime = saGhostBoxTiming;
        GameObject.Find("ArenaMaster").GetComponent<SASpawner>().scaleChange = saScaleChange;

        // change the max diameter, patrol speed, shrinkrate, and growthrate of safe zones
        foreach(Transform childSafeZone in GameObject.Find("SafeZoneWrapper_RandomBounce").transform){
            childSafeZone.gameObject.GetComponent<SizeChange>().maxScale = szMaxDiameter;
            childSafeZone.gameObject.GetComponent<SafeZoneMovement>().maxSpeed = szPatrolSpeed;
            childSafeZone.gameObject.GetComponent<SizeChange>().shrinkRate = szShrinkRate;
            childSafeZone.gameObject.GetComponent<SizeChange>().growthRate = szGrowthRate;
        }
        // GameObject.FindGameObjectsWithTag("Safe Zones").GetComponent<SizeChange>().maxScale = szMaxDiameter; //"BlueSafeZone" & "GreenSafeZone" & "RedSafeZone"
        // GameObject.FindGameObjectsWithTag("Safe Zones").GetComponent<SafeZoneMovement>().maxSpeed = szPatrolSpeed; // "BlueSafeZone" & "GreenSafeZone" & "RedSafeZone"
        // GameObject.FindGameObjectsWithTag("Safe Zones").GetComponent<SizeChange>().shrinkRate = szShrinkRate; // "BlueSafeZone" & "GreenSafeZone" & "RedSafeZone"
        // GameObject.FindGameObjectsWithTag("Safe Zones").GetComponent<SizeChange>().growthRate = szGrowthRate; // "BlueSafeZone" & "GreenSafeZone" & "RedSafeZone"

        // change speed firerate, and type of weapon
        GameObject.Find("Player").GetComponent<Move>().speed = playerSpeed; 
        GameObject.Find("Player").GetComponent<Shooting>().fireRate = playerFireRate;
        // GameObject.Find("Player").GetComponent<Shooting>().weapon = playerWeapon;  
    }
}
