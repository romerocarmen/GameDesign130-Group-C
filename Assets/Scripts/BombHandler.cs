using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(2f, 2f, 0f);
    private float timer;

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        gameObject.transform.localScale += scaleChange;
        if(timer > 1){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            other.gameObject.GetComponent<FollowTarget>().death();
        }
    }
}
