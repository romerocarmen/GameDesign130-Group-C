using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{

    public GameObject bombPrefab;
    private float timeSinceLastBomb = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastBomb += Time.deltaTime;
        if(Input.GetButtonDown("Bomb") && timeSinceLastBomb > 2){
            BigABomb();
        }
    }

    public void BigABomb(){
        Instantiate(bombPrefab, gameObject.transform.position, Quaternion.identity);
        timeSinceLastBomb = 0;
    }
}
