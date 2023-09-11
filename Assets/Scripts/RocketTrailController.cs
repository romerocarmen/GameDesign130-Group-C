using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTrailController : MonoBehaviour
{
    [SerializeField] public AudioClip theClip;
    [SerializeField] private AudioSource boosterAudio;
    [SerializeField] private float volume = 1f;

    [SerializeField] private bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            // Player input goes here
            if (Input.GetKey(KeyCode.Space))
            {
                foreach (Transform child in transform)
                    child.gameObject.SetActive(true);

            }
            else
            {
                foreach (Transform child in transform)
                    child.gameObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                boosterAudio.Play();
                isPlaying = true;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                boosterAudio.Stop();
                isPlaying = false;
            }
        }
    }
}
