using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public static void ShowScores()
    {
        GameObject.Find("First Player Score").GetComponent<Text>().text
            = $"Score: {GameController.Instance.FirstPlayerScore}";
        GameObject.Find("Second Player Score").GetComponent<Text>().text
            = $"Score: {GameController.Instance.SecondPlayerScore}";
    }
}
