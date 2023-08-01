using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILifeCounter : MonoBehaviour
{
    
    public void decrementLifeCounter(){
        Destroy(transform.GetChild(transform.childCount-1).gameObject);
    }
}
