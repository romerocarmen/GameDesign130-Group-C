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
        // update the level bar
        if(levelSlider.value != PlayerXPInteraction.totalXP)
        {
            levelSlider.value = PlayerXPInteraction.totalXP;

            // if the slider reaches 100, upgrade the level, reset bar and total XP
            if(levelSlider.value == 100)
            {
                LevelCounter.UpgradeLevel();
                PlayerXPInteraction.totalXP = 0;
            }
        }
    }
}