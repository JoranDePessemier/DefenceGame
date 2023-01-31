using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D _body;

    [SerializeField]
    private float _moveSpeed = 10;

    private void Awake()
    {
        _transform = this.transform;
        _body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _body.MovePosition(_body.position + (Vector2)_transform.up * _moveSpeed * Time.deltaTime);
    }
}
