using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float storedShake = 0; 
    public float shake = 0;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1;

    [SerializeField] private GameObject pauseScript;
    private PauseScript myPause; 

    public void Start()
    {
        myPause = pauseScript.GetComponent<PauseScript>();
    }

    public void Update()
    {
        if (shake > 0)
        {
            if (myPause.isPaused)
            {
                storedShake= shake;
                shake = 0;
            }
            else
            {
                this.transform.localPosition = Random.insideUnitSphere * shakeAmount;
                shake -= Time.deltaTime * decreaseFactor;
                storedShake = shake;
            }
            shake = storedShake;
        }
        else
        {
            shake = 0;
            storedShake= 0;
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

