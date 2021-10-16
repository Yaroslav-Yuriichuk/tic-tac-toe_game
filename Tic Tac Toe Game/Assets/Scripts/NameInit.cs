using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowNames();
        Scores.ShowScores();
    }
    
    private void ShowNames()
    {
        GameObject.Find("First Player Name").GetComponent<Text>().text
            = GameController.Instance.FirstPlayerName;
        GameObject.Find("Second Player Name").GetComponent<Text>().text
            = GameController.Instance.SecondPlayerName;
    }
}
