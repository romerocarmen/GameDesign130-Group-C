using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAttackHandler : MonoBehaviour
{
    public Vector3 scaleChange = new Vector3(1f, 0f, 0f);
    public float ghostBoxTime = 3;
    public float width = 15;

    private float timer;

    private void Awake() {
        gameObject.transform.localScale = new Vector3(1, width, 1);
    }

    // Update is called once per frame
    // Stage Attack grows
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        gameObject.transform.localScale += scaleChange;
        if(timer > ghostBoxTime){
            activateAttack();
        }
    }

    void activateAttack(){
        // Set color to be solid
        Color newColor = gameObject.GetComponent<SpriteRenderer>().color;
        newColor.a = 255;
        gameObject.GetComponent<SpriteRenderer>().color = newColor;

        // Set hitbox to on
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        // Wait for 1 second then destroy this object
        Destroy(gameObject, 1);

    }

    // Kills enemies of the same color, and kills the player if the player is 
    // not in the matching color of safe zone
    private void OnTriggerEnter2D(Collider2D other) {
        
        //Kills enemies of same color
        if(other.gameObject.tag == "Enemy"){
            //Check if color of attack and enemy are both red
            if(gameObject.tag == "RedStageAttack" && other.gameObject.layer == 6){
                Destroy(other.gameObject);
            }
            //Check if color of attack and enemy are both green
            if(gameObject.tag == "GreenStageAttack" && other.gameObject.layer == 7){
                Destroy(other.gameObject);
            }
            //Check if color of attack and enemy are both blue
            if(gameObject.tag == "BlueStageAttack" && other.gameObject.layer == 8){
                Destroy(other.gameObject);
            }
        }

        //Try to kill the player
        if(other.gameObject.tag == "Player"){
            //Check if color of attack and player safezone are both red
            if(gameObject.tag == "RedStageAttack" && other.gameObject.GetComponent<KillPlayer>().inRed == false){
                other.gameObject.GetComponent<KillPlayer>().Death();
            }
            //Check if color of attack and player safezone are both green
            if(gameObject.tag == "GreenStageAttack" && other.gameObject.GetComponent<KillPlayer>().inGreen == false){
                other.gameObject.GetComponent<KillPlayer>().Death();
            }
            //Check if color of attack and player safezone are both blue
            if(gameObject.tag == "BlueStageAttack" && other.gameObject.GetComponent<KillPlayer>().inBlue == false){
                other.gameObject.GetComponent<KillPlayer>().Death();
            }
        }


    }

}
