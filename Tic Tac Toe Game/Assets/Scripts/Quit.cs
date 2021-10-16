using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    private Button _button;
    
    // Start is called before the first frame update
    void Awake()
    {
        _button = gameObject.GetComponent<Button>();
    }

    void OnEnable()
    {
        _button.onClick.AddListener(QuitGame);
    }

    void OnDisable()
    {
        _button.onClick.RemoveListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();        
    }
    
}
