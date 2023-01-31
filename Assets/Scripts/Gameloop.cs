using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameloop : MonoBehaviour
{
    private StateMachine _sceneStateMachine = new StateMachine();
    private EnemySpawnerView _enemySpawner;

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawnerView>();
    }

    private void Start()
    {
        foreach(Wave wave in _enemySpawner.Waves)
        {
            _sceneStateMachine.Register(wave.TextSceneName, new TextSceneState(wave.TextSceneName));
        }

        _sceneStateMachine.Register("PlayState", new PlaySceneState(_enemySpawner));

        _sceneStateMachine.InitialState = "PlayState";


    }
}
