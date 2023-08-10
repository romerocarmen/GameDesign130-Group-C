using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteBulletChecker : MonoBehaviour
{
    public GameObject safeZone;
    private bool avoidingZone = false;
    private bool dodging = false;

    private void FixedUpdate() {
        if(avoidingZone && !dodging){
            transform.parent.transform.RotateAround(safeZone.transform.position, Vector3.forward, 40 * Time.deltaTime);
            transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = -(Vector3)(safeZone.transform.position - gameObject.transform.position).normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Bullet"){
            Debug.Log("Incoming bullet!");
            StartCoroutine(Dodge());
        }
        if(other.gameObject.name == safeZone.name){
            avoidingZone = true;
            transform.parent.gameObject.GetComponent<FollowTarget>().enabled = false;
            transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == safeZone.name){
            avoidingZone = false;
            transform.parent.gameObject.GetComponent<FollowTarget>().enabled = true;
        }
    }


    IEnumerator Dodge(){
        dodging = true;
        transform.parent.gameObject.GetComponent<FollowTarget>().enabled = false;
        // flip a coin to decide whether it dodges right or left
        if(Random.value < 0.5){
            transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = -transform.right * 50;
        } else {
            transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * 50;
        }
        yield return new WaitForSeconds(0.1f);
        transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.parent.gameObject.GetComponent<FollowTarget>().enabled = true; 
        dodging = false;
        
    }
}
