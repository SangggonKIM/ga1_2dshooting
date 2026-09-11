using UnityEngine;

public class ItemHealthUp : Item
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        Player player = other.GetComponent<Player>();
        if (player == null)
        {
            Debug.Log("플레이어 태그 오브젝트에 플레이어 컴포넌트가 없습니다.");
            return;
        }

        player.Heal((int)(_value));
        Debug.Log($"플레이어 체력: {player.GetHealth()}"); // readonly
        ShowGainEffect();
        Destroy(gameObject);
    }
}
