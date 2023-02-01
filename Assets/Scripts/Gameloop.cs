using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameloop : MonoBehaviour
{
    private StateMachine _sceneStateMachine = new StateMachine();
    private EnemySpawnerView _enemySpawner;
    private PlanetBehaviour _planetBehaviour;

    private void Awake()
    {
        _enemySpawner = FindObjectOfType<EnemySpawnerView>();
        _planetBehaviour = FindObjectOfType<PlanetBehaviour>();
    }

    private void Start()
    {
        foreach(Wave wave in _enemySpawner.Waves)
        {
            _sceneStateMachine.Register(wave.TextSceneName, new TextSceneState(wave.TextSceneName));
        }

        _sceneStateMachine.Register("PlayState", new PlaySceneState(_enemySpawner,_planetBehaviour));
        _sceneStateMachine.Register("GameOverState", new GameOverSceneState());
        _sceneStateMachine.Register("WinState", new WinSceneState());

        _sceneStateMachine.InitialState = "PlayState";


    }
}
