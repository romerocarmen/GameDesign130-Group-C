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

    public void StageAttackShake()
    {
        shakeAmount = 0.5f;
        decreaseFactor = 5f;
        shake = 1f;
    }

    public void BombShake()
    {
        shakeAmount = 0.7f;
        decreaseFactor = 1f;
        shake = 1f;
    }
}

