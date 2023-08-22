using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTrailController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(true);

        }
        else
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
        }
    }
}
