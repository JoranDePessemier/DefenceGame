using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToEnemies : MonoBehaviour
{
    [SerializeField]
    private LayerMask _enemyLayer;

    [SerializeField]
    private int _damageDealt = 1;

    [SerializeField]
    private bool _isBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if ((_enemyLayer & (1 << collisionObject.layer)) != 0)
        {
            if(collisionObject.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour behaviour))
            {
                Hit(behaviour);
            }
            else
            {
                Debug.LogWarning($"{this.gameObject} tried to deal damage to {collisionObject}, but the collisionObject does not have an enemybehaviour");
            }
        }
    }

    private void Hit(EnemyBehaviour enemyHit)
    {
        if(_isBullet && !enemyHit.IsShootable)
        {
            Destroy(this.gameObject);
        }
        else
        {
            enemyHit.CurrentHP -= _damageDealt;
        }
    }
}
