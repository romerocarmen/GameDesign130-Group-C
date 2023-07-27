using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour
{
    private Vector3 scaleChange = new Vector3(0.3f, 0.3f, 0f);
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.localScale += scaleChange;
        if(timer > 1){
            Destroy(gameObject, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            Destroy(other.gameObject);
        }
    }
}
