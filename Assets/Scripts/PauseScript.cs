using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseScript : MonoBehaviour
{
    public bool isPaused = false;
    public bool inSettings = false;
    [SerializeField] private float savedTimeScale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        savedTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause") && !isPaused)
        {
            savedTimeScale= Time.timeScale;
            GameObject.Find("LevelChangeIndicator").GetComponent<TMP_Text>().enabled = false;
            GameObject.Find("LevelChangeSubtext").GetComponent<TMP_Text>().enabled = false;
            AudioListener.pause = true;
            Time.timeScale = 0; 
            isPaused = true;

        } 
        else if (Input.GetButtonDown("Pause") && isPaused)
        {
            Unpause();
        }

        // control children
        if (isPaused && !inSettings)
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);

        }
        else
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);

        }
    }

    public void Unpause()
    {
        if(inSettings){
            GameObject.Find("SettingsCanvas").GetComponent<SettingsHandler>().ExitSettings();
        }
        GameObject.Find("LevelChangeIndicator").GetComponent<TMP_Text>().enabled = true;
        GameObject.Find("LevelChangeSubtext").GetComponent<TMP_Text>().enabled = true;
        AudioListener.pause = false;
        Time.timeScale = savedTimeScale;
        isPaused = false;
    }

    public void Settings(){
        inSettings = true;
        GameObject.Find("SettingsCanvas").GetComponent<SettingsHandler>().EnterSettings();
    }
}
