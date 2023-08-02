using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EndTimer : MonoBehaviour
{
    public GameObject EndTimeLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake() {
         EndTimeLabel.GetComponent<TMPro.TextMeshProUGUI>().text = TimeSpan.FromSeconds(Timer.timer).ToString(@"mm\:ss");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
