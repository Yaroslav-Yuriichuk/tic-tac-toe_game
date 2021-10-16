using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private EventTrigger _eventTrigger;
    private Image _image;

    private EventTrigger.Entry _clickEntry;
    private EventTrigger.Entry _pEnterEntry;
    private EventTrigger.Entry _pExitEntry;
    void Awake()
    {
        _eventTrigger = gameObject.GetComponent<EventTrigger>();
        _image = gameObject.GetComponent<Image>();
    }

    void OnEnable()
    {
        _clickEntry = new EventTrigger.Entry();
        _clickEntry.eventID = EventTriggerType.PointerClick;
        // _clickEntry.callback.AddListener(OpenCell);
        
        _pEnterEntry = new EventTrigger.Entry();
        _pEnterEntry.eventID = EventTriggerType.PointerEnter;
        // _pEnterEntry.callback.AddListener(ShowHighlightedFigure);
        
        _pExitEntry = new EventTrigger.Entry();
        _pExitEntry.eventID = EventTriggerType.PointerExit;
        // _pExitEntry.callback.AddListener(EraseFigure);
        
        AddListeners();
        
        _eventTrigger.triggers.Add(_clickEntry);
        _eventTrigger.triggers.Add(_pEnterEntry);
        _eventTrigger.triggers.Add(_pExitEntry);
    }

    void OnDisable()
    {
        _eventTrigger.triggers.Clear();
    }

    public void AddListeners()
    {
        _clickEntry.callback.AddListener(OpenCell);
        _pEnterEntry.callback.AddListener(ShowHighlightedFigure);
        _pExitEntry.callback.AddListener(EraseFigure);
    }

    public void RemoveListeners()
    {
        _clickEntry.callback.RemoveAllListeners();
        _pEnterEntry.callback.RemoveAllListeners();
        _pExitEntry.callback.RemoveAllListeners();
    }
    
    private void OpenCell(BaseEventData eventData){
        _image.sprite = GameController.Instance.CurrentFigure;
        _image.color = new Color(1, 1, 1, 1f);

        GameController.Instance.OpenCell(gameObject.name[6] - '0');
        
        RemoveListeners();
    }
    
    private void ShowHighlightedFigure(BaseEventData eventData)
    {
        _image.sprite = GameController.Instance.CurrentFigure;
        Color tmp = _image.color;
        tmp.a = 0.2f;
        _image.color = tmp;
    }

    private void EraseFigure(BaseEventData eventData)
    {
        _image.sprite = null;
        Color tmp = _image.color;
        tmp.a = 1f;
        _image.color = tmp;
    }
}
