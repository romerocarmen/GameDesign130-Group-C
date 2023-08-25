// When the player's level changes, three things happen
// 1. a noise plays that signals a levelup
// 2. New text appears to show player has levelled
// 3. the player gains an invincibility shield that lasts for 5 seconds
//    (to protect the player from dieing due to enemies covered by new text)


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpDing : MonoBehaviour
{
    private int currentLevel = 1;
    private TMP_Text textField;
    [SerializeField] public AudioClip levelUpClip; 
    [SerializeField] private AudioSource levelAudio;
    [SerializeField] private float volume = 3f;

    // Start is called before the first frame update
    void Start()
    {
        levelAudio = GetComponent<AudioSource>();
        textField = gameObject.GetComponent<TMP_Text>();
        //gameObject.GetComponent<TMP_Text>().color = Color.red;
        StartCoroutine(ChangeText());
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLevel != LevelCounter.levelValue){
            currentLevel = LevelCounter.levelValue;
            // play noise
            levelAudio.PlayOneShot(levelUpClip, volume);
            // make player invincible
            StartCoroutine(GameObject.Find("Player").GetComponent<KillPlayer>().InvincibilityTimer());
            // show text on screen
            StartCoroutine(ChangeText());
        }
    }

    IEnumerator ChangeText(){
        StartCoroutine(FadeTo(1f,1f));
        textField.text = "Level " + currentLevel;
        yield return new WaitForSeconds(3);
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
