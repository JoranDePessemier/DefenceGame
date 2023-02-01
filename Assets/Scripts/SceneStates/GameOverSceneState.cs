using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneState : State
{
    public override void OnEnter()
    {
        base.OnEnter();
        SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive);
    }

    public override void OnExit()
    {
        base.OnExit();
        SceneManager.UnloadSceneAsync("GameOver");
    }
}
