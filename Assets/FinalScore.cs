using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public GameObject finalScore;

    // Start is called before the first frame update
    private void Awake()
    {
        finalScore.GetComponent<TMPro.TextMeshProUGUI>().text = ScoreCounter.scoreValue.ToString();
        ScoreCounter.scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
