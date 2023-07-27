using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private bool invincible = false;
    public GameObject shield;
    private void Update() {
        if(Time.timeScale < 0.01f){
            gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
        }
    }

    // Death by enemy
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" && !invincible){
            // Make the player invincible
            invincible = true;
            // Stop time
            Time.timeScale = 0;
            //Set center of ship to color of whatever touched it
            gameObject.GetComponent<SpriteRenderer>().color = other.gameObject.GetComponentInChildren<SpriteRenderer>().color;
            // This sets the first child of the gameobject, the particle system, to be active
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // Does some wacky stuff since the time is stopped
            StartCoroutine(Deathstop());
        }
    }

    // Death by stage attack
    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    IEnumerator Deathstop(){
        // Time is stopped right now, so cannot wait for seconds normally
        // Only option is to use REAL TIME: record current real time in variable
        float startTime = Time.realtimeSinceStartup;
        // Loop runs until 3 seconds of real time has passed
        while(Time.realtimeSinceStartup - startTime < 3){
            yield return null;
        }
        // Everything after the loop runs only after 3 seconds has passed
        // Clear the screen
        gameObject.GetComponent<SpawnBomb>().BigABomb();
        // Reset the center of the ship to translucent white
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.36f);
        // Set particle emitter to stop
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        // Set time to move again
        Time.timeScale = 1;
        // Turn off player's invincibility in 5 seconds
        StartCoroutine(InvincibilityTimer());
    }

    IEnumerator InvincibilityTimer(){
        Instantiate(shield, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
        yield return new WaitForSeconds(5);
        invincible = false;
        Destroy(GameObject.FindWithTag("Shield"));
    }
}
