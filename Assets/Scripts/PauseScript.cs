using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public bool isPaused = false;
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
            Time.timeScale = 0; 
            isPaused = true;

        } 
        else if (Input.GetButtonDown("Pause") && isPaused)
        {
            Time.timeScale = savedTimeScale;
            isPaused= false;
        }

        // control children
        if (isPaused)
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
        Time.timeScale = savedTimeScale;
        isPaused = false;
    }
}
