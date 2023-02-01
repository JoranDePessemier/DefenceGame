using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveState : State
{
    private EnemySpawnerView _spawnerView;

    private List<EnemySpawn> _enemyList = new List<EnemySpawn>();

    private int _currentKills;

    private int _maxKills;

    private int _waveNumber;

    public WaveState(EnemySpawnerView spawnerView,int waveNumber)
    {
        _spawnerView = spawnerView;
        _enemyList = spawnerView.Waves[waveNumber].EnemySpawns;
        _maxKills = _enemyList.Count;
        _waveNumber = waveNumber;

    }

    public override void OnEnter()
    {
        base.OnEnter();
        SpawnEnemies();
        _spawnerView.UpKillCounter += UpKillCount;
    }

    public override void OnExit()
    {
        base.OnExit();
        _spawnerView.UpKillCounter -= UpKillCount;
    }

    private void UpKillCount(object sender, EventArgs e)
    {
        _currentKills++;
        SpawnEnemies();

        if(_currentKills >= _maxKills)
        {
            NextState();
        }
    }

    private void NextState()
    {
        if(_waveNumber < _spawnerView.Waves.Count - 1)
        {
            StateMachine.MoveTo($"Wave{_waveNumber + 1}");
            _spawnerView.NextStateLoaded(_waveNumber+1);
        }
        else
        {
            _spawnerView.EndWaves();
        }
    }

    private void SpawnEnemies()
    {
        foreach(EnemySpawn enemySpawn in _enemyList)
        {
            if(enemySpawn.RequiredKills == _currentKills)
            {
                _spawnerView.Spawn(enemySpawn.Enemy, enemySpawn.SpawnPoint);
            }
        }
    }
}
