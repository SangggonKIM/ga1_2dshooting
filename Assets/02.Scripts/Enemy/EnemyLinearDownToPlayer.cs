using System;
using UnityEngine;

public class EnemyLinearDownToPlayer : Enemy
{
    [SerializeField] private float _rotationOffset = 90f; // 스프라이트가 아래를 보니 조정값 +90
    private Vector2 _direction;
    private GameObject _player;


    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _direction = _player.transform.position - transform.position;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + _rotationOffset, Vector3.forward);
        // Quaternion.Euler(0f, 0f, angle + _rotationOffset) 오일러 좌표에서 Z축으로 회전.
        _direction.Normalize();
    }

    protected override void MoveAction()
    {
        if (_player == null) return;
        transform.position += (Vector3)(_direction * _moveSpeed * Time.deltaTime);
    }
}