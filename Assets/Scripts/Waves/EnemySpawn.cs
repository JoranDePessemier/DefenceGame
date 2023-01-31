using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemySpawn
{
    [SerializeField]
    private EnemyBehaviour _enemy;

    [SerializeField]
    private float _timeAfterRequiredKills;

    [SerializeField]
    private int _requiredKills;

    [SerializeField]
    private Vector2 _spawnPoint;


    public EnemyBehaviour Enemy => _enemy;

    public float TimeAfterRequiredKills => _timeAfterRequiredKills;

    public int RequiredKills => _requiredKills;

    public Vector2 SpawnPoint => _spawnPoint;

}
