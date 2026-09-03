using UnityEngine;

public class EnemyLinearDown : Enemy
{
    protected override void MoveAction()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}