using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public static Slider levelSlider;
    public int challengeLevel = 9;
    private float timeForXPSpawn = 0;
    public GameObject XP;

    void Start()
    {
        levelSlider = GetComponent<Slider>();
        levelSlider.value = 0;
    }

    void Update()
    {
        timeForXPSpawn += Time.deltaTime;

        // set the level bar limit (xp per level)
        levelSlider.maxValue = (LevelCounter.levelValue * 10) + 5;

        // if at challenge level, perform challenge level
        if(LevelCounter.levelValue == challengeLevel && timeForXPSpawn > 0.5)
        {
            SpawnXP();
            timeForXPSpawn = 0; 
        }

        // if at level 10, keep the bar full
        if (LevelCounter.levelValue == 10)
        {
            levelSlider.maxValue = 100;
            levelSlider.value = 100;
        }

        // update the level bar
        if(levelSlider.value != PlayerXPInteraction.totalXP && LevelCounter.levelValue != 10)
        {
            levelSlider.value = PlayerXPInteraction.totalXP;

            // if the slider reaches 100, upgrade the level, reset bar and total XP
            if(levelSlider.value == levelSlider.maxValue)
            {
                LevelCounter.UpgradeLevel();
                PlayerXPInteraction.totalXP = 0;
            }
        }
    }

    public void SpawnXP()
    {
        Instantiate(XP, new Vector2(Random.Range(-20f, 20f), Random.Range(-20f, 20f)), Quaternion.identity);
    }

    public static void ResetXP()
    {
        PlayerXPInteraction.totalXP = 0;
        levelSlider.value = 0;
    }
}