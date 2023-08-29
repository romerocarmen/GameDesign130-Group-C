using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSet : MonoBehaviour
{
    public Color color;
    // Start is called before the first frame update
    void Awake()
    {
        SetColor(color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(Color newColor){
        if(gameObject.GetComponent<SpriteRenderer>() != null){
            newColor.a = gameObject.GetComponent<SpriteRenderer>().color.a;
            gameObject.GetComponent<SpriteRenderer>().color = newColor;
        }

        foreach (Transform child in transform){
            if(child.gameObject.GetComponent<SpriteRenderer>() != null){
                newColor.a = child.gameObject.GetComponent<SpriteRenderer>().color.a;
                child.gameObject.GetComponent<SpriteRenderer>().color = newColor;
            }
            if(child.gameObject.GetComponent<ParticleSystem>() != null){
                newColor.a = 1;
                ParticleSystem.MainModule mainGuy = child.gameObject.GetComponent<ParticleSystem>().main;
                mainGuy.startColor = new ParticleSystem.MinMaxGradient(newColor);
            }
        }
    }
}
