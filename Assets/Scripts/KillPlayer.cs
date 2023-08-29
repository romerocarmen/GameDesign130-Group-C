using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public bool invincible = false;

    public int livesLeft = 3;
    public bool inRed = false;
    public bool inGreen = false;
    public bool inBlue = false;
    public GameObject shield;

    [SerializeField] private GameObject pauseScript;
    private void Update() {
        if(Time.timeScale < 0.01f){
            gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
        }
    }

    // Death by enemy
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy" && !invincible){
            //Set center of ship to color of whatever touched it
            gameObject.GetComponent<SpriteRenderer>().color = other.gameObject.GetComponentInChildren<SpriteRenderer>().color;
            //kill the player
            Death();
        }
    }

    // This sets player safety to stage attacks when they are in a safe zone
    // Death by Stage attack trigger is moved to script on the stage attack itself as it requires less checks there
    private void OnTriggerEnter2D(Collider2D other) {
        // Sets safety if player is in RedZone
        if(other.gameObject.tag == "RedSafeZone"){
            inRed = true;
        }

        // Sets safety if player is in GreenZone
        if(other.gameObject.tag == "GreenSafeZone"){
            inGreen = true;
        }

        // Sets safety if player is in BlueZone
        if(other.gameObject.tag == "BlueSafeZone"){
            inBlue = true;
        }
    }

    // This removes player safety to stage attacks when they have left a safe zone
    // Death by Stage attack trigger is moved to script on the stage attack itself as it requires less checks there
    private void OnTriggerExit2D(Collider2D other) {
        // Removes safety if player exits RedZone
        if(other.gameObject.tag == "RedSafeZone"){
            inRed = false;
        }

        // Removes safety if player exits GreenZone
        if(other.gameObject.tag == "GreenSafeZone"){
            inGreen = false;
        }

        // Removes safety if player exits BlueZone
        if(other.gameObject.tag == "BlueSafeZone"){
            inBlue = false;
        }
    }

    public void Death(){
        if(!invincible){
            // Make the player invincible
            invincible = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            // Stop time BUG HERE (but not really)
            Time.timeScale = 0;
            //freezes player rotation
            gameObject.GetComponent<Move>().orientToDirection = false;
            // This sets the first child of the gameobject, the particle system, to be active
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            // Does some wacky stuff since the time is stopped
            StartCoroutine(Deathstop());
        }
    }

    IEnumerator Deathstop(){
        // But the bug is also here, because it counts even when paused
        // only count when not paused? 
        // so need reference to that script
        // Time is stopped right now, so cannot wait for seconds normally
        // Only option is to use REAL TIME: record current real time in variable
        float startTime = Time.realtimeSinceStartup;
        float storedTime = startTime;
        bool stopParticle = false;
        // Loop runs until 3 seconds of real time has passed
        while (Time.realtimeSinceStartup - startTime < 3){
            if (pauseScript.GetComponent<PauseScript>().isPaused == true)
            {
                startTime += Time.unscaledDeltaTime;
                if(!stopParticle){
                    gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
                    stopParticle = true;
                }
            }
            else
            {   
                if(stopParticle){
                    gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                    stopParticle = false;
                }
            }   
            yield return null;
        }

        // Everything after the loop runs only after 3 seconds has passed
        // Clear the screen
        gameObject.GetComponent<SpawnBomb>().BigABomb();
        // Reset the center of the ship to translucent white
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.36f);
        // Set particle emitter to stop
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        // Decrement the player life counter
        GameObject.Find("LifeCounter").GetComponent<UILifeCounter>().decrementLifeCounter();
        livesLeft -= 1;
        if(livesLeft < 1){
            SceneManager.LoadScene(2);
        }
        // Set time to move again 
        // This is where the bug actually is

        Time.timeScale = 1;
        // Turn off player's invincibility in 5 seconds
        StartCoroutine(InvincibilityTimer());
        //unfreezes player rotation
        gameObject.GetComponent<Move>().orientToDirection = true;
    }

    public IEnumerator InvincibilityTimer(){
        invincible = true;
        Instantiate(shield, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
        yield return new WaitForSeconds(5);
        invincible = false;
        Destroy(GameObject.FindWithTag("Shield"));
    }
}
