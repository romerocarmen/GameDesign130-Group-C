using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBombCounter : MonoBehaviour
{
    int bombCount;
    
    private void Start() {
        bombCount = transform.childCount-1;
    }
    public void decrementBombCounter(){
        transform.GetChild(bombCount).gameObject.SetActive(false);
        bombCount--;
        //Destroy(transform.GetChild(transform.childCount-1).gameObject);
    }

    public void refillBombs(){
        foreach(Transform child in transform){
            child.gameObject.SetActive(true);
        }
        bombCount = transform.childCount-1;
    }
}
