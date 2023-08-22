using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public void HandleButton()
    {
        // reset the level values
        LevelCounter.ResetLevel();
        LevelProgress.ResetXP();
        ScoreCounter.ResetScore();
        Timer.timer = 0;
    }
}
