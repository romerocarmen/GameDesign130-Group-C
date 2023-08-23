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
    public float basicEnemySpawnRate = 0.5f;
    public float basicEnemySpawnDelta = 0.0005f;
    public float splitterSpawnRate = 0f;
    public float rainbowSpawnRate = 0f;
    public float advancedSpawnDelta = 0f;
    public float saSpawnRate = 0f;
    public float saSpawnDelta = 0f;
    public float saWidth = 0f;
    public float saGhostBoxTiming = 0f;
    public Vector3 saScaleChange = Vector3.zero;
    public bool saTargetPlayer = false;
    public float saMultiAttackChance = 0f;
    public float szMaxDiameter = 20f;
    public float szPatrolSpeed = 0f;
    public float szShrinkRate = 2f;
    public float szGrowthRate = 2f;

    private bool valuesChanged = false;
    
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
                playerFireRate = 6f;
                playerBulletCount = 1f;
                // playerWeapon = 2; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 5.5f;
                basicEnemySpawnRate = 1.1f;
                splitterSpawnRate = 0.1f;
                rainbowSpawnRate = 0.1f;

                // stage attack setters
                saSpawnRate = 0.5f;
                saWidth = 10f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(2f,0,0);
                saTargetPlayer = true;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 21f;
                szPatrolSpeed = 1f;
                szShrinkRate = 2.5f;
                szGrowthRate = 2f;
                
            }
            else if (level == 3)
            {
                // player setters
                playerSpeed = 3.2f;
                playerFireRate = 6f;
                playerBulletCount = 2f;
                // playerWeapon = 3; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 6f;
                basicEnemySpawnRate = 1.2f;
                splitterSpawnRate = 0.2f;
                rainbowSpawnRate = 0.2f;

                // stage attack setters
                saSpawnRate = 0f;
                saWidth = 0f;
                saGhostBoxTiming = 0f;
                //saScaleChange = 0;
                saTargetPlayer = true;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 22f;
                szPatrolSpeed = 1.1f;
                szShrinkRate = 3f;
                szGrowthRate = 2f;
            }
            else if (level == 4)
            {
                // player setters
                playerSpeed = 3.3f;
                playerFireRate = 7f;
                playerBulletCount = 2f;
                // playerWeapon = 4; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 6.5f;
                basicEnemySpawnRate = 1.3f;
                splitterSpawnRate = 0.2f;
                rainbowSpawnRate = 0.2f;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 18f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(1.5f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 23f;
                szPatrolSpeed = 1.2f;
                szShrinkRate = 3f;
                szGrowthRate = 2f;
            }
            else if (level == 5)
            {
                // player setters
                playerSpeed = 3.4f;
                playerFireRate = 7f;
                playerBulletCount = 3f;
                // playerWeapon = 5; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 7f;
                basicEnemySpawnRate = 1.4f;
                splitterSpawnRate = 0.3f;
                rainbowSpawnRate = 0.3f;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 18f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(1.5f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 24f;
                szPatrolSpeed = 1.3f;
                szShrinkRate = 3f;
                szGrowthRate = 1.5f;
            }
            else if (level == 6)
            {
                // player setters
                playerSpeed = 3.5f;
                playerFireRate = 8f;
                playerBulletCount = 3f;
                // playerWeapon = 6; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 7.5f;
                basicEnemySpawnRate = 1.5f;
                splitterSpawnRate = 0.4f;
                rainbowSpawnRate = 0.4f;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 15f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(2f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 25f;
                szPatrolSpeed = 1.4f;
                szShrinkRate = 3f;
                szGrowthRate = 1f;
            }
            else if (level == 7)
            {
                // player setters
                playerSpeed = 3.6f;
                playerFireRate = 8f;
                playerBulletCount = 4f;
                // playerWeapon = 7; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 8f;
                basicEnemySpawnRate = 1.5f;
                splitterSpawnRate = 0.5f;
                rainbowSpawnRate = 0.5f;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 15f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(2f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 26f;
                szPatrolSpeed = 1.5f;
                szShrinkRate = 3f;
                szGrowthRate = 1f;
            }
            else if (level == 8)
            {
                // player setters
                playerSpeed = 3.7f;
                playerFireRate = 9f;
                playerBulletCount = 4f;
                // playerWeapon = 8; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 8.5f;
                basicEnemySpawnRate = 1.6f;
                splitterSpawnRate = 0.6f;
                rainbowSpawnRate = 0.6f;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 15f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(2f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 27f;
                szPatrolSpeed = 1.6f;
                szShrinkRate = 3f;
                szGrowthRate = 1f;
            }
            else if (level == 9)
            {
                // player setters
                playerSpeed = 3.8f;
                playerFireRate = 9f;
                playerBulletCount = 5f;
                // playerWeapon = 9; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 9f;
                basicEnemySpawnRate = 1.7f;
                splitterSpawnRate = 0.8f;
                rainbowSpawnRate = 0.8f;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 15f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(2f, 0, 0);
                saTargetPlayer = false;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 28f;
                szPatrolSpeed = 1.7f;
                szShrinkRate = 4f;
                szGrowthRate = 3f;
            }
            else if (level == 10)
            {
                // player setters
                playerSpeed = 4f;
                playerFireRate = 10f;
                playerBulletCount = 5f;
                // playerWeapon = 10; need weapon upgrade number

                // enemy setters
                basicEnemySpeed = 10f;
                basicEnemySpawnRate = 2f;
                splitterSpawnRate = 1f;
                rainbowSpawnRate = 1f;

                // stage attack setters
                saSpawnRate = 0.1f;
                saWidth = 15f;
                saGhostBoxTiming = 2f;
                saScaleChange = new Vector3(2f, 0, 0);
                saTargetPlayer = true;
                saMultiAttackChance = 0f;

                // safe zone setters
                szMaxDiameter = 30f;
                szPatrolSpeed = 1.8f;
                szShrinkRate = 5f;
                szGrowthRate = 3f;
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
