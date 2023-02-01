using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneState : State
{
    private EnemySpawnerView _enemySpawner;
    private PlanetBehaviour _planetBehaviour;

    public PlaySceneState(EnemySpawnerView enemySpawner,PlanetBehaviour planetBehaviour)
    {
        _enemySpawner = enemySpawner;
        _planetBehaviour = planetBehaviour;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        Time.timeScale = 1;
        _enemySpawner.GoToTextScene += OpenTextScene;
        _enemySpawner.WavesEnd += EndGame;
        _planetBehaviour.PlayerDead += OpenGameOverScene;
        StateMachine.Push(_enemySpawner.Waves[0].TextSceneName);
    }

    private void EndGame(object sender, EventArgs e)
    {
        StateMachine.Push("WinState");
    }

    private void OpenGameOverScene(object sender, EventArgs e)
    {
        StateMachine.Push("GameOverState");
    }

    private void OpenTextScene(object sender, TextSceneEventArgs e)
    {
        StateMachine.Push(e.NextState);
    }

    public override void OnSuspend()
    {
        base.OnSuspend();
        _planetBehaviour.HealPlayerFull();
        Time.timeScale = 0;
    }

    public override void OnResume()
    {
        base.OnResume();
        Time.timeScale = 1;
    }


}
