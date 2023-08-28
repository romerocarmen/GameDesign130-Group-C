using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class PauseLeaderboard : MonoBehaviour
{
    [SerializeField] string userName;

    [SerializeField] TextMeshProUGUI name1;
    [SerializeField] TextMeshProUGUI name2;
    [SerializeField] TextMeshProUGUI name3;
    [SerializeField] TextMeshProUGUI name4;
    [SerializeField] TextMeshProUGUI name5;

    [SerializeField] TextMeshProUGUI score1;
    [SerializeField] TextMeshProUGUI score2;
    [SerializeField] TextMeshProUGUI score3;
    [SerializeField] TextMeshProUGUI score4;
    [SerializeField] TextMeshProUGUI score5;

    void Start()
    {
        name1 = GameObject.Find("firstPlaceName").GetComponent<TextMeshProUGUI>();
        name2 = GameObject.Find("secondPlaceName").GetComponent<TextMeshProUGUI>();
        name3 = GameObject.Find("thirdPlaceName").GetComponent<TextMeshProUGUI>();
        name4 = GameObject.Find("fourthPlaceName").GetComponent<TextMeshProUGUI>();
        name5 = GameObject.Find("fifthPlaceName").GetComponent<TextMeshProUGUI>();

        score1 = GameObject.Find("firstPlaceScore").GetComponent<TextMeshProUGUI>();
        score2 = GameObject.Find("secondPlaceScore").GetComponent<TextMeshProUGUI>();
        score3 = GameObject.Find("thirdPlaceScore").GetComponent<TextMeshProUGUI>();
        score4 = GameObject.Find("fourthPlaceScore").GetComponent<TextMeshProUGUI>();
        score5 = GameObject.Find("fifthPlaceScore").GetComponent<TextMeshProUGUI>();

        ConfigureBoard();
    }

    public void ConfigureBoard()
    {
        Dictionary<string, int> scoreDict = new Dictionary<string, int>()
        {
            { "BOB", 1220 },
            { "ACK", 455 },
            { "AZZ", 105 },
            { "DUD", 735 }
        };

        // default leaderboard input
        scoreDict.Add("DEF", 5);
        
        // sort by value
        var orderedDict = scoreDict.OrderByDescending(pair => pair.Value);

        // display
        name1.text = orderedDict.ElementAt(0).Key;
        name2.text = orderedDict.ElementAt(1).Key;
        name3.text = orderedDict.ElementAt(2).Key;
        name4.text = orderedDict.ElementAt(3).Key;
        name5.text = orderedDict.ElementAt(4).Key;

        score1.text = orderedDict.ElementAt(0).Value.ToString();
        score2.text = orderedDict.ElementAt(1).Value.ToString();
        score3.text = orderedDict.ElementAt(2).Value.ToString();
        score4.text = orderedDict.ElementAt(3).Value.ToString();
        score5.text = orderedDict.ElementAt(4).Value.ToString();
    }
}
