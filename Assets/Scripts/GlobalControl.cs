using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour 
{
    public static GlobalControl Instance;
    public Dictionary<string, int> scoreDict = new Dictionary<string, int>()
    {
        { "BOB", 1220 },
        { "ACK", 455 },
        { "AZZ", 105 },
        { "DUD", 735 },
        { "RGB", 5 }
    };

    void Awake ()   
       {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }
}
