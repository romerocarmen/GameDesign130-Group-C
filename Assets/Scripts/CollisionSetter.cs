using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set collisions between walls and enemies off
        Physics2D.IgnoreLayerCollision(3,6);
        Physics2D.IgnoreLayerCollision(3,7);
        Physics2D.IgnoreLayerCollision(3,8);

        // Set collisions between player and safe zones off
        Physics2D.IgnoreLayerCollision(0,9);
        Physics2D.IgnoreLayerCollision(0,10);
        Physics2D.IgnoreLayerCollision(0,11);

        // Set collisions between enemies and safe zones off
        //Red
        Physics2D.IgnoreLayerCollision(6,10);
        Physics2D.IgnoreLayerCollision(6,11);
        //Green
        Physics2D.IgnoreLayerCollision(7,9);
        Physics2D.IgnoreLayerCollision(7,11);
        //Blue
        Physics2D.IgnoreLayerCollision(8,9);
        Physics2D.IgnoreLayerCollision(8,10);

        // Set collisions between NoSpawnBubble and safe zones off
        Physics2D.IgnoreLayerCollision(12,9);
        Physics2D.IgnoreLayerCollision(12,10);
        Physics2D.IgnoreLayerCollision(12,11);

        // Set collisions between NoSpawnBubble and stage attacks off
        Physics2D.IgnoreLayerCollision(12,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
