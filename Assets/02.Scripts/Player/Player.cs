using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100.0f;
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        if (healAmount < 0)
        {
            Debug.LogWarning("힐량은 음수일 수 없습니다.");
            return;
        }
        _health += healAmount;
    }
}
