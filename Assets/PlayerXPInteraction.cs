using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXPInteraction : MonoBehaviour
{
    // tracking the number of XP collected
    public static int totalXP = 0;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // XP disappears if it comes into contact with player object
        if (collider.CompareTag("Player"))
        {
            // Finds the audio source
            AudioSource audio = GameObject.Find("Sound Effect").GetComponent<AudioSource>();
            // Plays the sound
            audio.Play();
            // add XP to counter
            totalXP += 2;
            // Destroy the XP
            Destroy(gameObject);
        }
    }
}