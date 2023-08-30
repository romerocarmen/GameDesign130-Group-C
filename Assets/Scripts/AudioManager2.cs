using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource musicSource;

    [Header("-----Audio Clip-----")]
    public AudioClip gameOver;

    public static AudioManager2 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = gameOver;
        musicSource.Play();
    }

    void Update()
    {
        if (Application.loadedLevelName == "StartScene")
        {
            Destroy(this.gameObject);
        }

        if (Application.loadedLevelName == "StartLeaderboard")
        {
            Destroy(this.gameObject);
        }

        if (Application.loadedLevelName == "SampleScene")
        {
            Destroy(this.gameObject);
        }

        if (Application.loadedLevelName == "PauseLeaderboard")
        {
            Destroy(this.gameObject);
        }

        if (Application.loadedLevelName == "Credits")
        {
            Destroy(this.gameObject);
        }

        if (Application.loadedLevelName == "ControllerScene")
        {
            Destroy(this.gameObject);
        }
    }
}