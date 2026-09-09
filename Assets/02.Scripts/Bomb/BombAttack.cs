using UnityEngine;

public class BombAttack : MonoBehaviour
{
    [SerializeField] private float _bombDamage = 9999f;

    private void Start()
    {
        Destroy(gameObject, 3f);
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
