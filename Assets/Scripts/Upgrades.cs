using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public int level = LevelCounter.levelValue;
    public float playerSpeed = 3f;
    public float playerFireRate = 1f;
    public float playerBulletCount = 1f;
    public float basicEnemySpeed = 5f; 
    public float splitterSpeed = 5f;
    public float basicEnemySpawnRate = 1f;
    public float basicEnemySpawnDelta = 0.0001f; // how quickly the spawn rate increases over time 
    public float splitterSpawnRate = 0f; 
    public float rainbowSpawnRate = 0f;
    public float advancedSpawnDelta = 0f; // how quickly splitter and rainbow enemies increase over time
    public int minEnemyCount = 1; // the minimum enemies spawned of the same color on a side at once
    public int maxEnemyCount = 1; // the maximum enemies spawned of the same color on a side at once
    public float saSpawnRate = 0f; // stage attack spawn rate
    public float saSpawnDelta = 0f; // how quickly the stage attack spanws increase over time
    public float saWidth = 0f; // stage attack width
    public float saGhostBoxTiming = 0f; // how quickly the stage attacks become active after launching
    public Vector3 saScaleChange = Vector3.zero; // how quickly the stage attacks go across the screen. Only the x value matters
    public bool saTargetPlayer = false; // turn true if we want stage attacks to spawn at the position of the player
    public float saMultiAttackChance = 0f; // the chance of having double stage attacks (1 vertical and 1 horizontal)
    public float szMaxDiameter = 20f; // safe zone diameter
    public float szPatrolSpeed = 0f; // how quickly the safezones move about the screen
    public float szShrinkRate = 0.5f; // how quickly the safezones shrink while the player is in them
    public float szGrowthRate = 1f; // how quickly the safezones grow back when the player leaves them
    private bool valuesChanged = false; // used for updating the values per level
    
    void Awake()
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
            if (level == 1)
            {
                // player setters
                // playerSpeed = 3f;
                // playerFireRate = 5f;
                // playerWeapon = 2; need weapon upgrade number

                // enemy setters
                // basicEnemySpeed = 5f;
                // basicEnemySpawnRate = 1f;
                // splitterSpawnRate = 0f;
                // rainbowSpawnRate = 0f;

                // stage attack setters
                // saSpawnRate = 0f;
                // saWidth = 0f;
                // saGhostBoxTiming = 0f;
                // saScaleChange = 0;

                // safe zone setters
                // szMaxDiameter = 20f;
                // szPatrolSpeed = 0f;
                // szShrinkRate = 0f;
                // szGrowthRate = 0f;

                changeGameValues();
                valuesChanged = true;
            }
                if (level == 2)
            {
                // player setters
                playerSpeed = 3.1f;
                playerFireRate++;
                playerBulletCount = 1f;

                // enemy setters
                basicEnemySpeed = 5f;
                basicEnemySpawnRate = 1f;
                splitterSpawnRate = 0.1f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 1;

                // stage attack setters
                saSpawnRate = 0;
                saWidth = 0;
                saGhostBoxTiming = 0;
                saScaleChange = new Vector3(0f,0,0);
                saTargetPlayer = true;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1f;
                szShrinkRate = 0.6f;
                szGrowthRate = 0.9f;
                
            }
            else if (level == 3)
            {
                // player setters
                playerSpeed = 3.2f;
                playerFireRate = 5f;
                playerBulletCount = 2f;

                // enemy setters
                basicEnemySpeed = 5f;
                basicEnemySpawnRate = 0.5f;
                splitterSpawnRate = 0.1f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 2;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 15f;
                saGhostBoxTiming = 3.5f;
                saScaleChange = new Vector3(1f,0,0);
                saTargetPlayer = false;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1.25f;
                szShrinkRate = 0.7f;
                szGrowthRate = 0.8f;
            }
            else if (level == 4)
            {
                // player setters
                playerSpeed = 3.3f;
                playerFireRate++;
                playerBulletCount = 2f;

                // enemy setters
                basicEnemySpeed = 5f;
                basicEnemySpawnRate = 0.5f;
                splitterSpawnRate = 0.1f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 3;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 15f;
                saGhostBoxTiming = 3f;
                saScaleChange = new Vector3(1.1f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0.5f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1.1f;
                szShrinkRate = 0.8f;
                szGrowthRate = 0.7f;
            }
            else if (level == 5)
            {
                // player setters
                playerSpeed = 3.4f;
                playerFireRate = 6f;
                playerBulletCount = 3f;

                // enemy setters
                basicEnemySpeed = 7f;
                basicEnemySpawnRate = 0.5f;
                splitterSpawnRate = 0.5f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 4;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 14f;
                saGhostBoxTiming = 3f;
                saScaleChange = new Vector3(1.2f, 0, 0);
                saTargetPlayer = true;
                saMultiAttackChance = 0.5f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1.2f;
                szShrinkRate = 0.9f;
                szGrowthRate = 0.6f;
            }
            else if (level == 6)
            {
                // player setters
                playerSpeed = 3.5f;
                playerFireRate++;
                playerBulletCount = 3f;

                // enemy setters
                basicEnemySpeed = 6f;
                basicEnemySpawnRate = 0.5f;
                splitterSpawnRate = 0.4f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 4;

                // stage attack setters
                saSpawnRate = 0.2f;
                saWidth = 13f;
                saGhostBoxTiming = 2.5f;
                saScaleChange = new Vector3(1.3f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0.5f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1.3f;
                szShrinkRate = 1f;
                szGrowthRate = 0.5f;
            }
            else if (level == 7)
            {
                // player setters
                playerSpeed = 3.6f;
                playerFireRate = 7f;
                playerBulletCount = 4f;

                // enemy setters
                basicEnemySpeed = 7f;
                basicEnemySpawnRate = 0.5f;
                splitterSpawnRate = 0.5f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 4;

                // stage attack setters
                saSpawnRate = 0.2f;
                saWidth = 12f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(1.4f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0.5f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1.4f;
                szShrinkRate = 1f;
                szGrowthRate = 0.5f;
            }
            else if (level == 8)
            {
                // player setters
                playerSpeed = 3.7f;
                playerFireRate++;
                playerBulletCount = 4f;

                // enemy setters
                basicEnemySpeed = 8f;
                basicEnemySpawnRate = 0.5f;
                splitterSpawnRate = 0.6f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 2;

                // stage attack setters
                saSpawnRate = 0.3f;
                saWidth = 11f;
                saGhostBoxTiming = 1.5f;
                saScaleChange = new Vector3(2f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0.5f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1.5f;
                szShrinkRate = 1f;
                szGrowthRate = 0.5f;
            }
            else if (level == 9)
            {
                // player setters
                playerSpeed = 3.8f;
                playerFireRate = 8f;
                playerBulletCount = 5f;

                // enemy setters
                basicEnemySpeed = 9f;
                basicEnemySpawnRate = 0.5f;
                splitterSpawnRate = 0.8f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 4;

                // stage attack setters
                saSpawnRate = 0.4f;
                saWidth = 10f;
                saGhostBoxTiming = 1.5f;
                saScaleChange = new Vector3(3f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0.5f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1.6f;
                szShrinkRate = 1f;
                szGrowthRate = 0.5f;
            }
            else if (level == 10)
            {
                // player setters
                playerSpeed = 4f;
                playerFireRate = 10f;
                playerBulletCount = 5f;

                // enemy setters
                basicEnemySpeed = 10f;
                basicEnemySpawnRate = 1f;
                splitterSpawnRate = 1f;
                rainbowSpawnRate = 0.1f;
                minEnemyCount = 1;
                maxEnemyCount = 4;

                // stage attack setters
                saSpawnRate = 0.5f;
                saWidth = 10f;
                saGhostBoxTiming = 1f;
                saScaleChange = new Vector3(3f, 0, 0);
                saTargetPlayer = true;
                saMultiAttackChance = 1f;

                // safe zone setters
                szMaxDiameter = 20f;
                szPatrolSpeed = 1.7f;
                szShrinkRate = 1f;
                szGrowthRate = 0.5f;
            }
            changeGameValues();
            valuesChanged = true;
        }
        
    }

    void changeGameValues(){
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().basicEnemySpeed = basicEnemySpeed;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().spawnRateBasic = basicEnemySpawnRate;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().spawnDelta = basicEnemySpawnDelta;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().minEnemyCount = minEnemyCount;
        GameObject.Find("ArenaMaster").GetComponent<EnemySpawner>().maxEnemyCount = maxEnemyCount;
        
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
        GameObject.Find("ArenaMaster").GetComponent<SASpawner>().targetPlayer = saTargetPlayer;
        GameObject.Find("ArenaMaster").GetComponent<SASpawner>().multiAttackChance = saMultiAttackChance;

        // change the max diameter, patrol speed, shrinkrate, and growthrate of safe zones
        foreach (Transform childSafeZone in GameObject.Find("SafeZoneWrapper_RandomBounce").transform){
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
        GameObject.Find("Player").GetComponent<Shooting>().numBullets = playerBulletCount;
        // GameObject.Find("Player").GetComponent<Shooting>().weapon = playerWeapon;  
    }
}
