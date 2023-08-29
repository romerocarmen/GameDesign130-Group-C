using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SafeZoneMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Transform staticCompassTarget;
    //[SerializeField] private float speed = 15f;
    //[SerializeField] private float lowerSpeed = 5f;

    [SerializeField] public float maxSpeed = 5f;
    [SerializeField] public float followSpeedMultiplier = 2f; 
    [SerializeField] public float speedAcc = .05f;
    [SerializeField] private float currentSpeed;
    [SerializeField] public bool isPlayer = false;

    [SerializeField] private bool isRandomOnExit = false; 

    private Vector2 directionToPlayer;
    // Use this for initialization
    void Start()
    {
        isPlayer = false;
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));

        rb2d = this.GetComponent<Rigidbody2D>();

        //float aSpeed = Random.Range(speed, lowerSpeed);

        //rb2d.AddForce(transform.right * aSpeed);
        StartCoroutine(speedIncrease());
        //StartCoroutine(reAimTowardsPlayer());
    }

    // Update is called once per frame
    void Update()
    {

        currentSpeed = rb2d.velocity.magnitude;


    }

    void LateUpdate()
    {
        if (!isPlayer)
        {
            Vector3 worldDirectionToPointForward = rb2d.velocity.normalized;
            Vector3 localDirectionToPointForward = Vector3.right;

            Vector3 currentWorldForwardDirection = transform.TransformDirection(
                   localDirectionToPointForward);
            float angleDiff = Vector3.SignedAngle(currentWorldForwardDirection,
                    worldDirectionToPointForward, Vector3.forward);

            transform.Rotate(Vector3.forward, angleDiff, Space.World);
        }
        else
        {
            lookAtPlayer();
            moveTowardsPlayer();
            //rb2d.AddForce(transform.right * speedAcc * Time.deltaTime);
        }

    }

    public void moveTowardsPlayer()
    {
        directionToPlayer = (staticCompassTarget.transform.position - transform.position).normalized;
        rb2d.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * maxSpeed * followSpeedMultiplier;
    }


    public void lookAtPlayer()
    {
        Vector3 targ = staticCompassTarget.transform.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    IEnumerator reAimTowardsPlayer()
    {
        float mySpeed = rb2d.velocity.magnitude;
        if (isPlayer)
        {

            rb2d.velocity = Vector3.zero;
            rb2d.AddForce(transform.right * mySpeed * Time.deltaTime);
        }
        yield return null;//new WaitForSeconds(.5f);
        StartCoroutine(reAimTowardsPlayer());
    }

    IEnumerator speedIncrease()
    {
        if (!isPlayer)
        {
            if (currentSpeed < maxSpeed / 2)
            {
                rb2d.AddForce(transform.right * 2 * speedAcc * Time.deltaTime);
            }
            else if (currentSpeed < maxSpeed)
            {

                rb2d.AddForce(transform.right * speedAcc * Time.deltaTime);
            }
            else if (currentSpeed > (2 * maxSpeed))
            {
                rb2d.AddForce(-transform.right * speedAcc * Time.deltaTime);
            }
        }
        yield return null;
        StartCoroutine(speedIncrease());
    }

    // check colliders here 
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            // do whatever the lava does to the player such as reduce player health or shield
            isPlayer = true;
            rb2d.velocity= Vector3.zero;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            // do whatever the lava does to the player such as reduce player health or shield
            isPlayer = false;
            rb2d.velocity = Vector3.zero;
            if (isRandomOnExit)
            {
                transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
            }
        }
    }
}
