using System;
using UnityEngine;

public class ItemDamgeUp : Item
{
    private Bullet _bullet;
    private void OnTriggerEnter2D(Collider2D player)
    {
        Destroy(gameObject);
        Debug.Log("부딪힘");
        _bullet.IncreaseDamage();
    }
}
