using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Follow Target")]
[RequireComponent(typeof(Rigidbody2D))]
public class FollowTarget : Physics2DObject
{
	// This is the target the object is going to move towards
	public Transform target;

	[Header("Movement")]
	// Speed used to move towards the target
	public float speed = 1f;

	// Used to decide if the object will look at the target while pursuing it
	public bool lookAtTarget = false;

	// The direction that will face the target
	public Enums.Directions useSide = Enums.Directions.Up;

	// ADDED TO SCRIPT BY JARED 
	private Vector2 directionToPlayer; 
	
	
	// FixedUpdate is called once per frame
	void FixedUpdate ()
	{
		// // check the color of this enemy, and if the player is in the corresponding color zone then the enemy swaps to wandering instead
		// // first make sure the enemy is targeting the player
		// if(target.name == "Player"){
		// 	switch(gameObject.layer){
		// 		//This enemy is RED
		// 		case 6:
		// 			if(target.gameObject.GetComponent<KillPlayer>().inRed){
		// 				gameObject.GetComponent<Wander>().enabled = true;
		// 				gameObject.GetComponent<Wander>().target = target;
		// 			}
		// 			break;
		// 		//This enemy is GREEN
		// 		case 7:
		// 			if(target.gameObject.GetComponent<KillPlayer>().inGreen){
		// 				gameObject.GetComponent<Wander>().enabled = true;
		// 				gameObject.GetComponent<Wander>().target = target;
		// 			}
		// 			break;
		// 		//This enemy is BLUE
		// 		case 8:
		// 			if(target.gameObject.GetComponent<KillPlayer>().inBlue){
		// 				gameObject.GetComponent<Wander>().enabled = true;
		// 				gameObject.GetComponent<Wander>().target = target;
		// 			}
		// 			break;
		// 		default:
		// 			break;
		// 	}
		// }
		

		//do nothing if the target hasn't been assigned or it was detroyed for some reason
		if(target == null)
			return;

		//look towards the target
		if(lookAtTarget)
		{
			Utils.SetAxisTowards(useSide, transform, target.position - transform.position);
		}
		
		//Move towards the target
		//NOTE: I am changing the script here to not use the pre-included line,
		//  	as the Lerp operation causes the velocity of the following object
		//		to grow faster the further away the target is, which isn't great for enemy AI
		//rigidbody2D.MovePosition(Vector2.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed));

		directionToPlayer = (target.transform.position - transform.position).normalized;
		rigidbody2D.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;

	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "TargetSwitcher"){
			target = GameObject.Find("Player").transform;
		}
	}

	private void OnCollisionEnter2D(Collision2D other){
		switch(gameObject.layer){
			// Enemy is RED
			case 6:
			if(other.gameObject.tag == "RedSafeZone"){
				Destroy(gameObject);
			}
			break;

			// Enemy is GREEN
			case 7:
			if(other.gameObject.tag == "GreenSafeZone"){
				Destroy(gameObject);
			}
			break;
			// Enemy is BLUE
			case 8:
			if(other.gameObject.tag == "BlueSafeZone"){
				Destroy(gameObject);
			}
			break;
			default:
			break;
		}
	}
}
