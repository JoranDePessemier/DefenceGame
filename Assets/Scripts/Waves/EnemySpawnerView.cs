using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerView : MonoBehaviour
{
    [SerializeField]
    private List<Wave> _waves;

    public List<Wave> Waves => _waves;

    private StateMachine _waveStateMachine = new StateMachine();

    private List<EnemyBehaviour> _spawnedEnemies = new List<EnemyBehaviour>();

    public event EventHandler<EventArgs> UpKillCounter;

    private void Start()
    {
        for (int i = 0; i < Waves.Count; i++)
        {
            _waveStateMachine.Register($"Wave{i}", new WaveState(this, i));
        }

        _waveStateMachine.InitialState = "Wave0";
        
    }

    private void Update()
    {
        for (int i = _spawnedEnemies.Count-1; i >= 0;   i--)
        {
            if(  _spawnedEnemies[i] == null)
            {
                _spawnedEnemies.RemoveAt(i);
                OnUpKillCounter(EventArgs.Empty);
            }
        }
    }

    internal void Spawn(EnemyBehaviour enemy, Vector2 spawnPoint)
    {
        GameObject spawnedEnemy = GameObject.Instantiate(enemy.gameObject, spawnPoint, enemy.transform.rotation);
        _spawnedEnemies.Add(spawnedEnemy.GetComponent<EnemyBehaviour>());

    }

    private void OnUpKillCounter(EventArgs eventArgs)
    {
        var handler = UpKillCounter;
        handler?.Invoke(this, eventArgs);
    }

    internal void EndWaves()
    {
        throw new NotImplementedException();
    }

    #region Debug
#if UNITY_EDITOR || DEBUG
    [Header("DEBUG")]
    [SerializeField]
    private int _currentDebugWave;

    [SerializeField]
    private int _currentDebugEnemy;

    private void OnDrawGizmosSelected()
    {
        try
        {
            Debug.DrawLine(Vector3.zero, _waves[_currentDebugWave].EnemySpawns[_currentDebugEnemy].SpawnPoint, Color.red);
        }
        catch
        {
            return;
        }
       
    }
#endif

    #endregion
}
