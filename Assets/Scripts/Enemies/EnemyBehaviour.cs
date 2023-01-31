using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool _isShootable = true;

    [SerializeField]
    private int _maxHP = 1;

    public int CurrentHP { get; set; }

    public bool IsShootable => _isShootable;

    protected virtual void Start()
    {
        CurrentHP = _maxHP;
    }

    protected virtual void Update()
    {
        if(CurrentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    
}
