using System;
using UnityEngine;

public class EnemyFollowPlayer : Enemy
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player == null)
        {
            Debug.LogError("플레이어 태그를 가진 게임 오브젝트를 찾지 못했습니다.");
            return;
        }
    }

    protected override void MoveAction()
    {
        if (_player == null) return;
        Vector2 direction = _player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}