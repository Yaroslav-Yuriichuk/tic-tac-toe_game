using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartRound : MonoBehaviour
{
    private Button _button;
    
    void Awake()
    {
        _button = gameObject.GetComponent<Button>();
    }

    void OnEnable()
    {
        _button.onClick.AddListener(ResetNewRound);
    }

    void OnDisable()
    {
        _button.onClick.RemoveListener(ResetNewRound);
    }

    private void ResetNewRound()
    {
        GameController.Instance.RestartRound();
        
        foreach (GameObject cell in GameObject.FindGameObjectsWithTag("Cell"))
        {
            Image image = cell.GetComponent<Image>();
            image.sprite = null;
            image.color = new Color(
                0.8196079f,
                0.7803922f,
                0.5058824f,
                1f);
            (cell.GetComponent<Cell>()).RemoveListeners();
            (cell.GetComponent<Cell>()).AddListeners();
        }
        
        ((Menu)GameObject.FindObjectOfType<Canvas>().GetComponent<Menu>()).ResetGameEnded();
        ((Menu)GameObject.FindObjectOfType<Canvas>().GetComponent<Menu>()).CloseMenu();
    }
}
