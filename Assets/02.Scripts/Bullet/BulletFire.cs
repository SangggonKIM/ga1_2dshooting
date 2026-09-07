using System;
using UnityEngine;

public class BulletFire : Bullet
{
    [SerializeField] private float _plusDamage = 10.0f;
    public override void IncreaseDamage()
    {
        BulletDamage += _plusDamage;
    }
}