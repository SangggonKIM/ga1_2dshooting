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
}
