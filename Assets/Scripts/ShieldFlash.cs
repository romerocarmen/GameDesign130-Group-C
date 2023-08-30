using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFlash : MonoBehaviour
{
    private float timer = 0;
    private Color tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.GetComponent<SpriteRenderer>().color = tmp;
        timer += Time.deltaTime;
        if(timer > 3){
            if(tmp.a <= 0){
                tmp.a = 1;
            } else {
                tmp.a = tmp.a - .03f;
            }
        }
    }
}
