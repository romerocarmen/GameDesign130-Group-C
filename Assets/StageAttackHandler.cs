using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAttackHandler : MonoBehaviour
{
    public Vector3 scaleChange = new Vector3(0.15f, 0f, 0f);
    private float timer;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    // Stage Attack grows
    void Update()
    {
        timer += Time.deltaTime;
        gameObject.transform.localScale += scaleChange;
        if(timer > 3){
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
}
