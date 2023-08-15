using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePlayerInteraction : MonoBehaviour
{
    // tracking the score
    public static int totalScore = 0;

    // update score based on the enemy type
    public static void UpdateScore(string enemyType)
    {
        if (enemyType == "BlueEnemy(Clone)" || enemyType == "GreenEnemy(Clone)" || enemyType == "RedEnemy(Clone)")
        {
            totalScore += 5;
        }
        else if (enemyType == "BlueSplitter(Clone)" || enemyType == "GreenSplitter(Clone)" || enemyType == "RedSplitter(Clone)" || enemyType == "RainbowSplitter(Clone)")
        {
            totalScore += 5;
        }
        else if (enemyType == "RainbowEnemy(Clone)")
        {
            totalScore += 10;
        }
    }
}