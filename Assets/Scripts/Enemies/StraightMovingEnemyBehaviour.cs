using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovingEnemyBehaviour : EnemyBehaviour
{
    //TODO Change this
    public Vector2 _movementTarget { get; set; } = new Vector2(0, 0);

    private Rigidbody2D _body;

    [SerializeField]
    private float _moveSpeed = 10;

    private void Awake()
    {
        _body = this.GetComponent<Rigidbody2D>();
    }

    protected  void FixedUpdate()
    {
        Vector2 movementVector = (_movementTarget - _body.position).normalized;

        _body.MovePosition(_body.position + movementVector * Time.deltaTime * _moveSpeed);

    }
}
