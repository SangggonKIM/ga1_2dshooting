using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage = 30.0f;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) return;
        Player player = collision.gameObject.GetComponent<Player>();
        if (player == null)
        {
            Debug.LogWarning("플레이어가 NULL 입니다.");
            return;
        }
        player.TakeDamage(_damage);
        Destroy(gameObject);
    }
}