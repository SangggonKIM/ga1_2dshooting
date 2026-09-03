using System;
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

    // 트리거 관련 이벤트
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("충돌 해브렸다.!");

        // 나 죽고
        Destroy(this.gameObject);

        // 충돌한 친구가 Enemy일때만 죽어뿔자!
        if (collider.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();

            // 응집도는 높히고, 결합도는 낮춰라
            // 결합도란 묻는거.. 매번 묻는거..
            // 무적모드 검사하고
            // 방어력 검사..
            enemy.TakeDamage(BulletDamage);
        }
    }

    // 충돌 관련 이벤트 (Enter -> stay -> Exit)

    // 충돌이 시작되면 호출되는 이벤트 함수
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("충돌 해브렸다.!");

        // 나 죽고
        Destroy(this.gameObject);

        // 충돌한 친구가 Enemy일때만 죽어뿔자!
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // GetComponent<타입>() -> 게임 오브젝트가 가지고 있는 컴포넌트를 참조
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            // 응집도는 높히고, 결합도는 낮춰라
            // 결합도란 묻는거.. 매번 묻는거..
            // 무적모드 검사하고
            // 방어력 검사..
            enemy.TakeDamage(BulletDamage);
        }
    }*/

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Debug.Log("충돌 중이다.!!");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Debug.Log("충돌이 완료 됐다.!!!");
    }
}