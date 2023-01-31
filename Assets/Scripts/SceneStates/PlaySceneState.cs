using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneState : State
{
    private EnemySpawnerView _enemySpawner;

    public PlaySceneState(EnemySpawnerView enemySpawner)
    {
        _enemySpawner = enemySpawner;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Time.timeScale = 1;
        _enemySpawner.GoToTextScene += OpenTextScene;
        StateMachine.Push(_enemySpawner.Waves[0].TextSceneName);
    }

    private void OpenTextScene(object sender, TextSceneEventArgs e)
    {
        StateMachine.Push(e.NextState);
    }

    public override void OnSuspend()
    {
        base.OnSuspend();
        Time.timeScale = 0;
    }

    public override void OnResume()
    {
        base.OnResume();
        Time.timeScale = 1;
    }


}
