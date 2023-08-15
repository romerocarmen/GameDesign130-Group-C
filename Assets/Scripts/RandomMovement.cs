using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    //[SerializeField] private float speed = 15f;
    //[SerializeField] private float lowerSpeed = 5f;

    [SerializeField] public float maxSpeed = 5f;
    [SerializeField] public float speedAcc = .05f;
    [SerializeField] private float currentSpeed; 
    // Use this for initialization
    void Start()
    {

        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

        rb2d = this.GetComponent<Rigidbody2D>();

        //float aSpeed = Random.Range(speed, lowerSpeed);

        //rb2d.AddForce(transform.right * aSpeed);
        StartCoroutine(speedIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = rb2d.velocity.magnitude; 
        
    }

    void LateUpdate()
    {
        Vector3 worldDirectionToPointForward = rb2d.velocity.normalized;
        Vector3 localDirectionToPointForward = Vector3.right;

        Vector3 currentWorldForwardDirection = transform.TransformDirection(
                localDirectionToPointForward);
        float angleDiff = Vector3.SignedAngle(currentWorldForwardDirection,
                worldDirectionToPointForward, Vector3.forward);

        transform.Rotate(Vector3.forward, angleDiff, Space.World);
    }

    IEnumerator speedIncrease()
    {
        
        if (currentSpeed < maxSpeed)
        {

            rb2d.AddForce(transform.right * speedAcc * Time.deltaTime);
        }
        
        yield return null;
        StartCoroutine(speedIncrease());
    }

}
