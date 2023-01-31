using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    [SerializeField]
    private List<EnemySpawn> _enemySpawns;

    [SerializeField]
    private string _textSceneName;

    public List<EnemySpawn> EnemySpawns => _enemySpawns;

    public string TextSceneName => _textSceneName;

}
