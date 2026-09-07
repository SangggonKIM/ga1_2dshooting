using UnityEngine;

public class ItemFireRateUp : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerFire player = other.GetComponent<PlayerFire>();
        if (player == null)
        {
            Debug.Log("플레이어 태그 오브젝트에 플레이어 컴포넌트가 없습니다.");
            return;
        }
        player.FireRateUp(_value);
        Destroy(gameObject);
    }
}
