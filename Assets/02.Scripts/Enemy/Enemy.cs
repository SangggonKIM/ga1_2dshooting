using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100;
    [SerializeField] protected float _moveSpeed = 1.0f;

    private void Update()
    {
        MoveAction();
    }

    protected abstract void MoveAction();


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