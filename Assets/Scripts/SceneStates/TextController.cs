using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
   


    [SerializeField]
    private List<TextMeshProUGUI> _texts;

    private int _currentTextNumber;
    public event EventHandler<EventArgs> StopScene;

    private void Start()
    {
        foreach(TextMeshProUGUI text in _texts)
        {
            text.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_currentTextNumber < _texts.Count - 1)
            {
                _texts[_currentTextNumber].gameObject.SetActive(true);
                _currentTextNumber++;
            }
            else
            {
                OnStopScene(EventArgs.Empty);
            }
        }
    }

    private void OnStopScene(EventArgs e)
    {
        var handler = StopScene;
        handler?.Invoke(this, e);
    }
}
