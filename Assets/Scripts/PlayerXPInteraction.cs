using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXPInteraction : MonoBehaviour
{
    // tracking the number of XP collected
    public static int totalXP = 0;
    private float timer = 0;
    private Color tmp;
    private float flashSpeed = 0.003f;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void FixedUpdate() {
        
        timer += Time.deltaTime;
        // if (timer > 10){
        //     flashSpeed = 0.01f;
        // }

        for(int i = 0; i < transform.childCount; i++){
            if(transform.GetChild(i).GetComponent<SpriteRenderer>() != null){
                tmp = transform.GetChild(i).GetComponent<SpriteRenderer>().color;
                if(tmp.a <= 0){
                    if (timer > 10){
                        flashSpeed = 0.03f;
                    }
                    flashSpeed = -Mathf.Abs(flashSpeed);
                    tmp.a = 0;
                } else if(tmp.a >= 1){
                    if (timer > 10){
                        flashSpeed = 0.03f;
                    }
                    flashSpeed = Mathf.Abs(flashSpeed);
                    tmp.a = 1;
                }

                tmp.a = tmp.a - flashSpeed;
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = tmp;
            }
        }

        // foreach(SpriteRenderer sprite in sprites){
        //     tmp = sprite.color;
        //     if(tmp.a <= 0){
        //         tmp.a = 1;
        //     } else {
        //         tmp.a = tmp.a - flashSpeed;
        //     }
        //     sprite.color = tmp;
        // }
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // XP disappears if it comes into contact with player
        if (collider.CompareTag("Player"))
        {
            // Finds the audio source
            AudioSource audio = GameObject.Find("Sound Effect").GetComponent<AudioSource>();
            // Plays the sound
            audio.Play();
            // add XP to counter
            totalXP += 1;
            // Destroy the XP
            Destroy(gameObject);
        }
    }
}