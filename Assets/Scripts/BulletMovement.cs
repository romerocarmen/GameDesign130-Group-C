using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    [SerializeField]

    private GameObject XP;
    private float speed = 5.0f;
    float maxDistance = 100f;
    Vector3 startingPosition;
    bool placedXP = false;

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
        while(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 40){
            gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 1.1f * gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            // Finds the audio source
            AudioSource audio = GameObject.Find("Enemy Death Sound Effect").GetComponent<AudioSource>();
            // Plays the sound
            audio.Play();

            Vector3 endingPosition = other.gameObject.transform.position;
            Destroy(other.gameObject);

            // place XP where enemy was
            if (!placedXP)
            {
                GameObject tmpXP = Instantiate(XP);
                tmpXP.transform.position = endingPosition;
                placedXP = true;
            }

            ScorePlayerInteraction.UpdateScore(other.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Vector3 endingPosition = gameObject.transform.position;
            Destroy(gameObject);

            // place XP where enemy was
            if (!placedXP)
            {
                GameObject tmpXP = Instantiate(XP);
                tmpXP.transform.position = endingPosition;
                placedXP = true;
            }
        }
    }
}