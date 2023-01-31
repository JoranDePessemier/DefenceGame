using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerView : MonoBehaviour
{
    [SerializeField]
    private List<Wave> _waves;

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
}
