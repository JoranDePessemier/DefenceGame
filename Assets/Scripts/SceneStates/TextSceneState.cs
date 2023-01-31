using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextSceneState : State
{
    private string _sceneName;

    private TextController _textControl;

    public TextSceneState(string sceneName)
    {
        _sceneName = sceneName;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        var operation = SceneManager.LoadSceneAsync(_sceneName,LoadSceneMode.Additive);
        operation.completed += SetUpScene;
    }

    private void SetUpScene(AsyncOperation obj)
    {
        _textControl = GameObject.FindObjectOfType<TextController>();
        _textControl.StopScene += OnStop;
    }

    private void OnStop(object sender, EventArgs e)
    {
        StateMachine.Pop();
        _textControl.StopScene -= OnStop;
    }

    public override void OnExit()
    {
        base.OnExit();
        SceneManager.UnloadSceneAsync(_sceneName);
    }
}
