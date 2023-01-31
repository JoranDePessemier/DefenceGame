using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetBehaviour : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;

    [SerializeField]
    private LayerMask _enemyLayer;

    [SerializeField]
    private int _enemyDamage;

    [SerializeField]
    private int _bulletDamage;

    [SerializeField]
    private PlayerShooting _shootScript;

    [SerializeField]
    private Image _healthUI;

    private int _currentHealth;

    private void Awake()
    {
        _shootScript.ShotBullet += OnShotBullet;
        _currentHealth = _maxHealth;
    }

    private void OnShotBullet(object sender, EventArgs e)
    {
        _currentHealth -= _bulletDamage;
        SetUI();
        CheckDeath();
    }

    private void SetUI()
    {
        _healthUI.fillAmount = (float)_currentHealth / (float)_maxHealth;
    }

    private void CheckDeath()
    {
        if(_currentHealth <= 0)
        {
            Debug.Log($"Player hp is {_currentHealth}, ded");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if ((_enemyLayer & (1 << collisionObject.layer)) != 0)
        {
            _currentHealth -= _enemyDamage;
            CheckDeath();
        }
    }
}
