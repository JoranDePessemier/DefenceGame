using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerShooting : MonoBehaviour
{
    private float _currentShootingTimer;

    private bool _canShoot;

    private bool _mousePlacedDownInScene;

    private Transform _transform;

    public event EventHandler<EventArgs> ShotBullet;

    [SerializeField]
    private float _timeBetweenShots = 1;

    [SerializeField]
    private float _fireDistance;

    [SerializeField]
    private Transform _bulletPrefab;

    [SerializeField]
    private UnityEvent _shoot;



    private void Awake()
    {
        _transform = this.transform;
    }


    private void Shoot()
    {
        GameObject.Instantiate(_bulletPrefab, _transform.position + _transform.up * _fireDistance, _transform.rotation);
        OnShotBullet(EventArgs.Empty);
        _shoot.Invoke();
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

    private void OnShotBullet(EventArgs eventArgs)
    {
        var handler = ShotBullet;
        handler?.Invoke(this, eventArgs);
    }
}
