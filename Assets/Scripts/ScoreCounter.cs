using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] public static TextMeshProUGUI scoreCounter;
    public static int scoreValue;

    void Start()
    {
        scoreCounter = GetComponent<TextMeshProUGUI>();
        scoreValue = 0;
        scoreCounter.text = scoreValue.ToString();
    }

    void Update()
    {
        // update the score
        if(scoreValue != ScorePlayerInteraction.totalScore)
        {
            Debug.Log("updating the score");
            scoreValue = ScorePlayerInteraction.totalScore;
            scoreCounter.text = scoreValue.ToString();
        }
    }

    public static void ResetScore()
    {
        ScorePlayerInteraction.totalScore = 0;
        scoreValue = 0;
        scoreCounter.text = scoreValue.ToString();
    }
}