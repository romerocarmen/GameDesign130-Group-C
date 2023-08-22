using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScreen : MonoBehaviour
{
    public void MoveToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitTheGame()
    {
        Debug.Log("Quit: This only works outside the Unity Editor");
        Application.Quit();
    }

}
