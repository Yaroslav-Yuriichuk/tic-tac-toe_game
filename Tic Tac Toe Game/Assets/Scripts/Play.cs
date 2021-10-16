using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    private Button _button;
    // Start is called before the first frame update
    void Awake()
    {
        _button = gameObject.GetComponent<Button>();
    }

    void OnEnable()
    {
        _button.onClick.AddListener(StartGame);
    }

    void OnDisable()
    {
        _button.onClick.RemoveListener(StartGame);
    }

    private void StartGame()
    {
        string firstPlayerName = GameObject.Find("First Player Text").GetComponent<Text>().text;
        string secondPlayerName = GameObject.Find("Second Player Text").GetComponent<Text>().text;

        if (ValidateInput(firstPlayerName, secondPlayerName))
        {
            GameController.Instance.SetNames(firstPlayerName, secondPlayerName);
            SceneManager.LoadScene(1);    
        }
    }

    private bool ValidateInput(string firstPlayerName, string secondPlayerName)
    {
        return firstPlayerName != "" && secondPlayerName != "";
    }
}
