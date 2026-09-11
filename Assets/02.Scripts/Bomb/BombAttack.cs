using UnityEngine;

public class BombAttack : MonoBehaviour
{
    [SerializeField] private float _bombDamage = 9999f;
    [SerializeField] private float _timer = 3.0f;

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("폭탄 충돌!!!");
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(_bombDamage);
        }
    }
}
