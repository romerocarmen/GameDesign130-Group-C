using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    public TextMeshProUGUI userName;

    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI name3;
    public TextMeshProUGUI name4;
    public TextMeshProUGUI name5;

    public TextMeshProUGUI score1;
    public TextMeshProUGUI score2;
    public TextMeshProUGUI score3;
    public TextMeshProUGUI score4;
    public TextMeshProUGUI score5;

    public void ConfigureBoard()
    {
        Dictionary<string, int> scoreDict = new Dictionary<string, int>()
        {
            { "JSB", 1220 },
            { "ACK", 455 },
            { "LHF", 320 },
            { "KMN", 735 }
        };

        userName.GetComponent<TMPro.TextMeshProUGUI>();
        scoreDict.Add(userName.ToString(), ScorePlayerInteraction.totalScore);

        // sort by value
        var orderedDict = scoreDict.OrderByDescending(pair => pair.Value);

        // display
        name1.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(0).Key;
        name2.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(1).Key;
        name3.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(2).Key;
        name4.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(3).Key;
        name5.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(4).Key;

        score1.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(0).Key.ToString();
        score2.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(1).Key.ToString();
        score3.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(2).Key.ToString();
        score4.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(3).Key.ToString();
        score5.GetComponent<TMPro.TextMeshProUGUI>().text = orderedDict.ElementAt(4).Key.ToString();
    }
}
