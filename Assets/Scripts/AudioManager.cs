using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source-----")]
    [SerializeField] AudioSource musicSource;

    [Header("-----Audio Clip-----")]
    public AudioClip mainMenu;

    public static AudioManager instance;

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
        musicSource.clip = mainMenu;
        musicSource.Play();
    }

    void Update()
    {
        if (Application.loadedLevelName == "ControllerScene")
        {
            Destroy(this.gameObject);
        }
    }
}