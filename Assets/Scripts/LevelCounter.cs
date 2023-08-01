using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCounter : MonoBehaviour
{
    [SerializeField] public static TextMeshProUGUI levelCounter;
    public static int levelValue;

    void Start()
    {
        levelCounter = GetComponent<TextMeshProUGUI>();
        levelValue = 1;
        levelCounter.text = levelValue.ToString();
    }

    public static void UpgradeLevel()
    {
        levelValue++;
        levelCounter.text = levelValue.ToString();
    }
}