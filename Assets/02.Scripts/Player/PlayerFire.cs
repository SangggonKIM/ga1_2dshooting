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

    public void SetAuto(bool auto)
    {
        _autoFireToggle = auto;
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
                float finalFireRate = CoolTime - UpgradeManager.Instance.Upgrades[1].CurrentValue;
                CoolTimer = finalFireRate;
            }
        }
    }

    private void AutoFire()
    {
        _autoFireToggle = !_autoFireToggle;
    }

    private void FireBullet()
    {
        BasicFireBullet(BulletType.Main, FirePoint);
    }

    private void FireAssistBullet()
    {
        BasicFireBullet(BulletType.Sub, AssistFirePoint);
    }

    private void BasicFireBullet(BulletType bulletType, Transform[] basicFirePoint)
    {
        foreach (Transform firePoint in basicFirePoint)
        {
            Bullet bullet = BulletPool.Instance.GetBullet(bulletType);
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

    // todo: 버튼 클릭할 때 애니메이션 주기 + 사운드 주기
    // 애니메이션: 코드로 구현 약간 커졌다가 원래대로..
    // 사운드: 일레븐랩스에서 버튼 클릭 공용 사운드 만들어서 적용
}
