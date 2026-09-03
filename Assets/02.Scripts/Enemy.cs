using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] private float _moveSpeed = 1.0f;

    private void Update()
    {
        MoveAction();
    }

    protected virtual void MoveAction()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            // 너죽자!
            Destroy(gameObject);
        }
    }
}