using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SizeChange : MonoBehaviour {

    [Header("Control Settings")]
    [SerializeField] private float origScale = 1f; 
    [SerializeField] public float maxScale = 1.5f;
    [SerializeField] public float minScale = .5f;
    [SerializeField] public float shrinkRate = 1f;
    [SerializeField] public float growthRate = 1f;

    // old var
    //[SerializeField] private float changeSpeed = .01f;



    [Header("Runtime Settings")]
    [SerializeField] public float scale = 1f;
    [SerializeField] public bool isPlayer = false; 

    // old var
    //[SerializeField] private float targetMax = 0f;
    //[SerializeField] private float targetMin = 0f;
    //[SerializeField] private bool startsDecreasing = true;


    // Start is called before the first frame update
    void Start()
    {

        gameObject.layer = 14;
        isPlayer = false; 
        scale = origScale;
        transform.localScale = new Vector2(scale, scale);

        //startsDecreasing = randomBoolean();
        //StartCoroutine(SizeOscillation());
    }

    // Update is called once per frame
    void Update()
    {
        // control size here
        if (isPlayer)
        {

            shrink();

        } 
        else
        {

            swell();

        }

    }

    public void shrink()
    {
        // decrease size
        if (scale > minScale)
        {
            scale -= shrinkRate * Time.deltaTime;
            transform.localScale = new Vector2(scale, scale);

        }
    }

    public void swell()
    {
        // increase size
        if (scale < maxScale)
        {
            scale += growthRate * Time.deltaTime;
            transform.localScale = new Vector2(scale, scale);

        }

    }

    // check colliders here 
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            // do whatever the lava does to the player such as reduce player health or shield
            isPlayer = true; 
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            // do whatever the lava does to the player such as reduce player health or shield
            isPlayer = false;
        }
    }


  
}
