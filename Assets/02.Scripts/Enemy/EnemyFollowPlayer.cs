using System;
using UnityEngine;

public class EnemyFollowPlayer : Enemy
{
    [SerializeField] private float _rotationOffset = 90f; // 스프라이트가 아래를 보니 조정값 +90
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + _rotationOffset, Vector3.forward);
        direction.Normalize();
        transform.position += (Vector3)(direction * _moveSpeed * Time.deltaTime);
    }
}
