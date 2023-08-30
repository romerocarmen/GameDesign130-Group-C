using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject Bullet;
    private float timeSinceLastBullet = 1;
    public float fireRate = 5;
    public float numBullets = 1;

    [SerializeField] public AudioClip theClip;
    [SerializeField] private AudioSource bulletAudio;
    [SerializeField] private float volume = 1f;

    void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        timeSinceLastBullet += Time.deltaTime;
        if (Input.GetMouseButton(0) && timeSinceLastBullet > 1/fireRate) //&& Time.time > canFire
        {
            float bulletsToFire = numBullets;
            float flipAngle = .1f;
            Bullet.GetComponent<BulletMovement>().heading = gameObject.GetComponent<Move>().heading.normalized;
            bulletAudio.PlayOneShot(theClip, volume);
            if (bulletsToFire % 2 == 0){
                Instantiate(Bullet, transform.position + transform.up*.3f, transform.rotation);
                Instantiate(Bullet, transform.position - transform.up*.3f + transform.right * .75f, transform.rotation);
                bulletsToFire -= 2;
            } else {
                Instantiate(Bullet, transform.position, transform.rotation);
                bulletsToFire--;
            }

            while(bulletsToFire > 0){
                Bullet.GetComponent<BulletMovement>().heading = gameObject.GetComponent<Move>().heading.normalized + transform.up * flipAngle;
                Instantiate(Bullet, transform.position, transform.rotation);
                bulletsToFire--;
                flipAngle = flipAngle * -1;
                if(flipAngle > 0){
                    flipAngle = flipAngle + .1f;
                }
            }
            timeSinceLastBullet = 0;
        }
    }
}