using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtextLevelScript : MonoBehaviour
{
    private int currentLevel = 1;
    private TMP_Text textField;
    private string[] textArray = new string[10] {"Can you make it to level 10?","+Fire Rate\nGetting Tougher!","+Bullets\nDo not touch the bars!","+Fire Rate","+Bullets","+Fire Rate","+Bullets","+Fire Rate","+Bullets","+Fire Rate/XP Disabled\nSurvive as long as you can!"};

    // Start is called before the first frame update
    void Start()
    {
        textField = gameObject.GetComponent<TMP_Text>();
        StartCoroutine(ChangeSubtext());
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLevel != LevelCounter.levelValue){
            currentLevel = LevelCounter.levelValue;
            // show text on screen
            StartCoroutine(ChangeSubtext());
        }
    }

    IEnumerator ChangeSubtext(){
        StartCoroutine(FadeTo(1f,1.5f));
        textField.text = textArray[currentLevel - 1];
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeTo(0f,1f));
    }

    IEnumerator FadeTo(float desiredAlpha, float desiredTime){
        float alpha = textField.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime/desiredTime){
            Color newColor = new Color(1,1,1, Mathf.Lerp(alpha,desiredAlpha,t));
            textField.color = newColor;
            yield return null;
        }
    }
}
