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
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = (Vector3)(Input.mousePosition - screenPoint);
        Utils.SetAxisTowards(Enums.Directions.Right, transform, direction);
		//gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(directionToMouse.x, directionToMouse.y) * speed;
        gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * speed, ForceMode2D.Impulse);
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