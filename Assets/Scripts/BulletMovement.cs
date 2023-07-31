using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;
    float maxDistance = 100f;
    Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(startingPosition, transform.position);
        
        if (currentDistance > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    void Awake()
    {
        startingPosition = transform.position;
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}