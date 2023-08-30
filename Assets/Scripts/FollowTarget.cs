using UnityEngine;
using System.Collections;

//[AddComponentMenu("Playground/Movement/Follow Target")]
[RequireComponent(typeof(Rigidbody2D))]
public class FollowTarget : Physics2DObject
{
	// This is the target the object is going to move towards
	public Transform target;

	[Header("Movement")]
	// Speed used to move towards the target
	public float speed = 1f;

	//private float currentSpeed = 1f;

	// Used to decide if the object will look at the target while pursuing it
	public bool lookAtTarget = false;

	// The direction that will face the target
	public Enums.Directions useSide = Enums.Directions.Up;

	// ADDED TO SCRIPT BY JARED 
	private Vector2 directionToPlayer; 
	
	private bool deathFlag = false;

	private float timer = 0;
	
	public bool splitEnemy = false;

    [SerializeField] public AudioClip theClip;

    // FixedUpdate is called once per frame
    void FixedUpdate ()
	{
		
		timer += Time.deltaTime;
		if(timer > .5 && splitEnemy){
			target = GameObject.Find("Player").transform;
		}
		

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
		// if(currentSpeed < speed){
		// 	currentSpeed = currentSpeed * 1.05f;
		// }
		// if(!deathFlag){
		// 	rigidbody2D.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;
		// } else {
		// 	//rigidbody2D.velocity = new Vector2(-directionToPlayer.x, -directionToPlayer.y) * speed;
		// }
		

	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "TargetSwitcher" && !splitEnemy){
			target = GameObject.Find("Player").transform;
		}
	}

	private void OnCollisionEnter2D(Collision2D other){
		switch(gameObject.layer){
			// Enemy is RED
			case 6:
			if(other.gameObject.tag == "RedSafeZone"){
				AudioSource.PlayClipAtPoint(theClip, new Vector3(0, 0, 0));
                AudioSource.PlayClipAtPoint(theClip, new Vector3(0, 0, 0));
                gameObject.GetComponent<FollowTarget>().death();
			}
			break;

			// Enemy is GREEN
			case 7:
			if(other.gameObject.tag == "GreenSafeZone"){
				AudioSource.PlayClipAtPoint(theClip, new Vector3(0, 0, 0));
                AudioSource.PlayClipAtPoint(theClip, new Vector3(0, 0, 0));
                gameObject.GetComponent<FollowTarget>().death();
			}
			break;
			// Enemy is BLUE
			case 8:
			if(other.gameObject.tag == "BlueSafeZone"){
				AudioSource.PlayClipAtPoint(theClip, new Vector3(0, 0, 0));
                AudioSource.PlayClipAtPoint(theClip, new Vector3(0, 0, 0));
                gameObject.GetComponent<FollowTarget>().death();
			}
			break;
			default:
			break;
		}
	}

	public void death(){
		// gameObject.GetComponent<Rigidbody2D>().simulated = false;
		// Rigidbody2D[] rb = gameObject.GetComponentsInChildren<Rigidbody2D>();
		// foreach(Rigidbody2D r in rb){
			
		// 	r.simulated = true;
		// 	directionToPlayer = (target.transform.position - transform.position).normalized;
		// 	rigidbody2D.velocity = new Vector2(-directionToPlayer.x, -directionToPlayer.y) * speed;
		// }
		if(deathFlag){
			return;
		}

		deathFlag = true;

		if(gameObject.GetComponent<BoxCollider2D>() != null){
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		} else if (gameObject.GetComponent<CircleCollider2D>() != null){
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			gameObject.GetComponent<Splitter>().spawnBaddies();
		}
		
		speed = 0;
		lookAtTarget = false;


		SpriteRenderer[] sprites = gameObject.GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer sprite in sprites){
			sprite.enabled = false;
		}


		StartCoroutine(deathAnimation());
	}
	IEnumerator deathAnimation(){
        
		transform.Find("deathParticles").gameObject.SetActive(true);





        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}