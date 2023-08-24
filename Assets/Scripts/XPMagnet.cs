using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPMagnet : MonoBehaviour
{
    private bool suckTime = false;
    private Vector2 directionToPlayer; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(suckTime){
            directionToPlayer = (GameObject.Find("Player").transform.position - transform.position).normalized;
		    transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * 20;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player"){
            suckTime = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
        
    }
}
