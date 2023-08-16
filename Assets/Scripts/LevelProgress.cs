using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    public static Slider levelSlider;

    void Start()
    {
        levelSlider = GetComponent<Slider>();
        levelSlider.value = 0;
    }

    void Update()
    {
        // set the level bar limit
        levelSlider.maxValue = (LevelCounter.levelValue * 5) + 5;

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

    public static void ResetXP()
    {
        PlayerXPInteraction.totalXP = 0;
        levelSlider.value = 0;
    }
}