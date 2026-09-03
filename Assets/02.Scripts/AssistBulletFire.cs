using System;
using UnityEngine;

public class AssistBulletFire : MonoBehaviour
{
    // 목적: 총알을 위로 움직이고 싶다.
    public float Speed = 3.0f;
    public float AssistBulletDamage = 1.0f;

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        Vector2 Direction = Vector2.up;
        transform.Translate(Direction * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Health -= AssistBulletDamage;
            if (enemy.Health <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
    }
}