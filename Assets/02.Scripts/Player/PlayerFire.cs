using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;

    public GameObject AssistBulletPrefab;

    // - 생성 위치(총구)
    public Transform[] FirePoint;
    public Transform[] AssistFirePoint;
    public float FireRate;
    private float _nextTime = 0.0f;
    private bool _autoFireToggle = false;

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
        if (Time.time > _nextTime)
        {
            if (Input.GetKey(KeyCode.Space) || _autoFireToggle)
            {
                FireBullet();
                FireAssistBullet();
                _nextTime = Time.time + FireRate;
            }
        }
    }

    private void AutoFire()
    {
        _autoFireToggle = !_autoFireToggle;
    }

    private void FireBullet()
    {
        BasicFireBullet(BulletPrefab, FirePoint);
    }

    private void FireAssistBullet()
    {
        BasicFireBullet(AssistBulletPrefab, AssistFirePoint);
    }

    private void BasicFireBullet(GameObject bulletPrefab, Transform[] basicFirePoint)
    {
        foreach (Transform firePoint in basicFirePoint)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}