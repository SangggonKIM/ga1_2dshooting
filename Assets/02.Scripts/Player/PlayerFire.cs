using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    // - 생성 위치(총구)
    public Transform[] FirePoint;
    public Transform[] AssistFirePoint;
    private const float MinCoolTime = 0.06f;
    public float CoolTime = 0.5f;
    public float CoolTimer = 0;
    private bool _autoFireToggle = false;

    private void Start()
    {
        CoolTimer = CoolTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AutoFire();
        }

        ManualFire();
    }

    private void ManualFire()
    {
        CoolTimer -= Time.deltaTime;
        if (CoolTimer <= 0)
        {
            if (Input.GetKey(KeyCode.Space) || _autoFireToggle)
            {
                FireBullet();
                FireAssistBullet();
                CoolTimer = CoolTime;
            }
        }
    }

    private void AutoFire()
    {
        _autoFireToggle = !_autoFireToggle;
    }

    private void FireBullet()
    {
        BasicFireBullet(FirePoint);
    }

    private void FireAssistBullet()
    {
        BasicFireBullet(AssistFirePoint);
    }

    private void BasicFireBullet(Transform[] basicFirePoint)
    {
        foreach (Transform firePoint in basicFirePoint)
        {
            Bullet bullet = BulletPool.Instance.GetBullet();
            bullet.transform.position = firePoint.position;
        }
    }

    public void FireRateUp(float upValue)
    {
        if (upValue < 0)
        {
            Debug.LogWarning("공격 속도 증가량은 0보다 작을 수 없습니다.");
            return;
        }

        CoolTime = Math.Max(CoolTime - upValue, MinCoolTime); // 둘중에 가장 높은수를 선택. 최소 쿨타임보다 작을 수 없다.
    }
}