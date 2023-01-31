using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _body;
    private Camera _mainCam;

    [SerializeField]
    private float _moveSpeed = 10;

    [SerializeField]
    private float _viewPortDespawnBuffer; 

    private void Awake()
    {
        _transform = this.transform;
        _body = this.GetComponent<Rigidbody2D>();
        _mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        _body.MovePosition(_body.position + (Vector2)_transform.up * _moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Vector2 vpPosition = _mainCam.WorldToViewportPoint(_transform.position);
        
        if(vpPosition.x >= 1 + _viewPortDespawnBuffer ||
            vpPosition.x <= -+_viewPortDespawnBuffer ||
            vpPosition.y >= 1 + _viewPortDespawnBuffer ||
            vpPosition.y <= -+_viewPortDespawnBuffer )
        {
            Destroy(this.gameObject);
        }
    }
}
