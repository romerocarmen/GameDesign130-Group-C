using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Bullet;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("I die");
            Destroy(gameObject); // destroying self object (Enemy Object)
            Destroy(collision.gameObject); // destroying collided object (Bullet Object)
        }
    }
}