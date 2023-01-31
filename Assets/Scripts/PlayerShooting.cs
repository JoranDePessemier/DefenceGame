using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerShooting : MonoBehaviour
{
    private float _currentShootingTimer;

    private bool _canShoot;

    private Transform _transform;

    [SerializeField]
    private float _timeBetweenShots = 1;

    [SerializeField]
    private Transform _bulletPrefab;

    private void Awake()
    {
        _transform = this.transform;
    }


    private void Shoot()
    {
        GameObject.Instantiate(_bulletPrefab, _transform.position, _transform.rotation);
    }

    private void Update()
    {
        if (_canShoot && Input.GetMouseButton(0)) 
        {
            Shoot();
            _currentShootingTimer = 0;
        }


        if (_currentShootingTimer <= _timeBetweenShots)
        {
            _currentShootingTimer+=Time.deltaTime;
            _canShoot = false;
        }
        else
        {
            _canShoot = true;
        }
    }
}
