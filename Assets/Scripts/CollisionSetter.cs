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
        Physics2D.IgnoreLayerCollision(3,13);

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
        //Rainbow
        Physics2D.IgnoreLayerCollision(13,9);
        Physics2D.IgnoreLayerCollision(13,10);
        Physics2D.IgnoreLayerCollision(13,11);

        // Set collisions between NoSpawnBubble and safe zones off
        Physics2D.IgnoreLayerCollision(12,9);
        Physics2D.IgnoreLayerCollision(12,10);
        Physics2D.IgnoreLayerCollision(12,11);

        // Set collisions between NoSpawnBubble and stage attacks off
        Physics2D.IgnoreLayerCollision(12,0);

        // Set collisions between everything but player and XP off
        // Physics2D.IgnoreLayerCollision(16, 1);
        // Physics2D.IgnoreLayerCollision(16, 2);
        // Physics2D.IgnoreLayerCollision(16, 3);
        // Physics2D.IgnoreLayerCollision(16, 4);
        // Physics2D.IgnoreLayerCollision(16, 5);
        // Physics2D.IgnoreLayerCollision(16, 6);
        // Physics2D.IgnoreLayerCollision(16, 7);
        // Physics2D.IgnoreLayerCollision(16, 8);
        // Physics2D.IgnoreLayerCollision(16, 9);
        // Physics2D.IgnoreLayerCollision(16, 10);
        // Physics2D.IgnoreLayerCollision(16, 11);
        // Physics2D.IgnoreLayerCollision(16, 12);
        // Physics2D.IgnoreLayerCollision(16, 13);
        // Physics2D.IgnoreLayerCollision(16, 14);
        // Physics2D.IgnoreLayerCollision(16, 15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
