using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Move With Arrows")]
[RequireComponent(typeof(Rigidbody2D))]
public class Move : Physics2DObject
{
    [Header("Input keys")]
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 5f;
    public Enums.MovementType movementType = Enums.MovementType.AllDirections;

    [Header("Orientation")]
    public bool orientToDirection = false;
    // The direction that will face the player
    public Enums.Directions lookAxis = Enums.Directions.Up;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;
    public Vector3 heading = Vector3.right;


    // Update gets called every frame
    void Update()
    {
        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = Input.GetAxis("Vertical2");
        }

        // not important
        //zero-out the axes that are not needed, if the movement is constrained
        switch (movementType)
        {
            case Enums.MovementType.OnlyHorizontal:
                moveVertical = 0f;
                break;
            case Enums.MovementType.OnlyVertical:
                moveHorizontal = 0f;
                break;
        }

        setMovement(); 


        float currentGameSpeed = Time.timeScale;
        if (currentGameSpeed != 0)
        {
            lookAtMouse();
        }
        //rotate the GameObject towards the direction of movement
        //the axis to look can be decided with the "axis" variable

    }

    private void setMovement()
    {
        movement = new Vector2(moveHorizontal, moveVertical);
    }

    private void lookAtMouse()
    {
        if (orientToDirection)
        {
            // if(movement.sqrMagnitude >= 0.01f)
            // {
            // 	cachedDirection = movement;
            // }
            // Utils.SetAxisTowards(lookAxis, transform, cachedDirection);
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            heading = (Vector3)(Input.mousePosition - screenPoint);
            Utils.SetAxisTowards(Enums.Directions.Right, transform, heading);
        }
    }



    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        // Apply the force to the Rigidbody2d
        //rigidbody2D.velocity = movement.normalized * speed;
        rigidbody2D.AddForce(movement * speed * 10f);
        //Debug.Log((movement * speed * 10f).magnitude);
        //if(movement == Vector2.zero){
        //	rigidbody2D.velocity = Vector2.zero;
        //}
    }
}