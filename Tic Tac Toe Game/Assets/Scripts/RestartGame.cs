using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    private Button _button;
    
    void Awake()
    {
        _button = gameObject.GetComponent<Button>();
    }

    void OnEnable()
    {
        _button.onClick.AddListener(ResetNewGame);
    }

    void OnDisable()
    {
        _button.onClick.RemoveListener(ResetNewGame);
    }

    private void ResetNewGame()
    {
        GameController.Instance.RestartGame();
    }
}
