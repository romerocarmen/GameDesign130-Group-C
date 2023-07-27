using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BigABomb(){
        Instantiate(bombPrefab, gameObject.transform.position, Quaternion.identity);
        Debug.Log("Bomb goes here");
    }
}
