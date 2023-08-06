using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float speed = 15f;
    [SerializeField] private float lowerSpeed = 5f;
    // Use this for initialization
    void Start()
    {

        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

        rb2d = this.GetComponent<Rigidbody2D>();

        float aSpeed = Random.Range(speed, lowerSpeed);

        rb2d.AddForce(transform.right * aSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
