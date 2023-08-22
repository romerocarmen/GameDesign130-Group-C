using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shake = 0;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1;
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && GameObject.Find("Player").GetComponent<SpawnBomb>().bombCount > 0)
        {
            shake = 1;
        }
        if (shake > 0)
        {
            this.transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0;
        }
    }
}
