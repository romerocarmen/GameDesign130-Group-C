using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBombCounter : MonoBehaviour
{

    public void decrementBombCounter(){
        Destroy(transform.GetChild(transform.childCount-1).gameObject);
    }
}
