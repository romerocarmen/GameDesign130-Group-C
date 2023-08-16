using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpDing : MonoBehaviour
{
    private int currentLevel = 1;
    [SerializeField] public AudioClip levelUpClip; 
    [SerializeField] private AudioSource levelAudio;
    [SerializeField] private float volume = 3f;

    // Start is called before the first frame update
    void Start()
    {
        levelAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLevel != LevelCounter.levelValue){
            currentLevel = LevelCounter.levelValue;
            levelAudio.PlayOneShot(levelUpClip, volume);
        }
    }
}
