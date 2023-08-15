using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;
    private float timeSinceLastBullet = 1;
    public float fireRate;
    //public float fireRate = 1f;
    //public float canFire = 1f;

    void Start()
    {

    }

    void Update()
    {
        timeSinceLastBullet += Time.deltaTime;
        if (Input.GetMouseButton(0) && timeSinceLastBullet > 1/fireRate) //&& Time.time > canFire
        {
           Instantiate(Bullet, transform.position, transform.rotation);
           timeSinceLastBullet = 0;
           //canFire = Time.time + fireRate;
        }
    }
}