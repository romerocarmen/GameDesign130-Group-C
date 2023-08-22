using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public int bombCount = 3;
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
        if(Input.GetButtonDown("Bomb") && timeSinceLastBomb > 2 && bombCount > 0){
            BigABomb();
            bombCount -= 1;
            GameObject.Find("BombCounter").GetComponent<UIBombCounter>().decrementBombCounter();
        }
    }

    public void BigABomb(){
        Instantiate(bombPrefab, gameObject.transform.position, Quaternion.identity);
        timeSinceLastBomb = 0;
        GameObject.Find("Main Camera").GetComponent<CameraShake>().shake = 1;
    }
}
