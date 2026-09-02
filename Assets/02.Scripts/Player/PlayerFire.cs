using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 목표: 스페이스바를 누를 때마다 총알을 생성해서 발사하고 싶다.
    // 필요 속성
    // - 총알 프리팹
    public GameObject BulletPrefab;
    // - 생성 위치(총구)
    public Transform[] FirePoint;
    public float FireRate;
    private float _nextTime = 0.0f;

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextTime)
        {
            foreach (Transform firePoint in FirePoint)
            {
                Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
            }
            
            _nextTime = Time.time + FireRate;
        }



    }
}
