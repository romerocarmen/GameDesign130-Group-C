using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;
    //public float fireRate = 1f;
    //public float canFire = 1f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //&& Time.time > canFire
        {
           Instantiate(Bullet, transform.position, transform.rotation);
           //canFire = Time.time + fireRate;
        }
    }
}