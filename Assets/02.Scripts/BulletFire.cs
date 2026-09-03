using UnityEngine;

public class BulletFire : MonoBehaviour
{
    // 목적: 총알을 위로 움직이고 싶다.
    public float Speed = 1.0f;
    public float BulletDamage = 1.0f;

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        Vector2 Direction = Vector2.up;
        transform.Translate(Direction * Speed * Time.deltaTime);
    }

    // 충돌 관련 이벤트 (Enter -> stay -> Exit)

    // 충돌이 시작되면 호출되는 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 해브렸다.!");

        // 나 죽고
        Destroy(this.gameObject);

        // 충돌한 친구가 Enemy일때만 죽어뿔자!
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Health -= BulletDamage;
            if (enemy.Health <= 0)
            {
                // 너죽자!
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("충돌 중이다.!!");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Debug.Log("충돌이 완료 됐다.!!!");
    }
}