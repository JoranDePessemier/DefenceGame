using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneState : State
{
    public override void OnEnter()
    {
        base.OnEnter();
        SceneManager.LoadSceneAsync("Win",LoadSceneMode.Additive);
    }

    public override void OnExit()
    {
        base.OnExit();
        SceneManager.UnloadSceneAsync("Win");
    }
}
