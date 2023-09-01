using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserName : MonoBehaviour
{
    public static string userNameInput;

    // Start is called before the first frame update
    void Start()
    {
        userNameInput = "RGB";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GetUserNameInput(string input)
    {
        userNameInput = input;
    }

    public static void ResetUserName()
    {
        userNameInput = "ABC";
    }
}
