using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool _menuIsOpened = false;
    private bool _gameEnded = false;
    
    [SerializeField] private GameObject _menuPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_gameEnded)
            {
                if (_menuIsOpened)
                {
                    CloseMenu();
                }
                else
                {
                    OpenMenu("Game Paused", false);
                }
            }
        }
    }

    public void OpenMenu(string message, bool gameEnded)
    {
        _menuPanel.SetActive(true);
        GameObject.Find("Message").GetComponent<Text>().text
            = message;
        _menuIsOpened = true;
        _gameEnded = gameEnded;
    }

    public void CloseMenu()
    {
        _menuPanel.SetActive(false);
        _menuIsOpened = false;
    }

    public void ResetGameEnded()
    {
        _gameEnded = false;
    }
}
