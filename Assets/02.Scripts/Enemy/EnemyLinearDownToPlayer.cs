using System;
using UnityEngine;

public class EnemyLinearDownToPlayer : Enemy
{
    private Vector2 _direction;
    private GameObject _player;


    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _direction = _player.transform.position - transform.position;
        _direction.Normalize();
    }

    protected override void MoveAction()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime);
    }
}