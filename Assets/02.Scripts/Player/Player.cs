using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health = 100.0f;
    [SerializeField] private GameObject _deathEffectPrefab;
    private PlayerSound _playerDamagedaudioSource;

    public float Health => _health; // 람다식 문법을 활용한 읽기 전용 프로퍼티
    // 잘 설계된 클래스는
    // - 필드 (인스턴스 변수)
    // - 필드에 잘못된 값이 할당되지 않게 막고, 정상적으로 동작하는 메서드
    // getter/setter : 특정 데이터를 get/set 해주는 메서드
    private void Awake()
    {
        _playerDamagedaudioSource = GetComponent<PlayerSound>();
    }
    public float GetHealth()
    {
        return _health;
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        _playerDamagedaudioSource.PlayDamagedSound();
        if (_health <= 0)
        {
            ShowDeathEffect();
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        if (healAmount < 0)
        {
            Debug.LogWarning("힐량은 음수일 수 없습니다.");
            return;
        }
        _health += healAmount;
    }

    private void ShowDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }
}
