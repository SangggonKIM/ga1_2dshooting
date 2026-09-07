using UnityEngine;

public class ItemSpeedUp : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        PlayerMove player = other.GetComponent<PlayerMove>();
        if (player == null)
        {
            Debug.Log("플레이어 태그 오브젝트에 플레이어 컴포넌트가 없습니다.");
            return;
        }
        player.SpeedUp(_value);
        Destroy(gameObject);
    }
}
