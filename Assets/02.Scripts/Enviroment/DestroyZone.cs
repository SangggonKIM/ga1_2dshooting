using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // 나와 닿는 모든 오브젝트를 제거한다.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}