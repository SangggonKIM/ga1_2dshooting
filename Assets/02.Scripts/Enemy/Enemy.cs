using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("아이템 목록 지정")]
    [SerializeField] private ItemSpawnDataTableSO _itemSpawnDataTable;
    [SerializeField] private float _damage = 30.0f;
    [SerializeField] private float _health = 100;
    [SerializeField] protected float _moveSpeed = 1.0f;
    private bool _isDead = false;
    private int _animHit = Animator.StringToHash("hitTrigger");
    private Animator _animator;
    // Todo: 에너미가 공격 당할때 재생시켜주는 피격 사운드
    private AudioSource _damagedaudioSource;
    // - 죽을때 생성할 파티클 프리팹
    [SerializeField] private GameObject _deathEffectPrefab;

    private void Awake()
    {
        // 애니메이터 컴포넌트에 대한 참조를 가져와서 할당한다.
        _animator = GetComponent<Animator>();
        _damagedaudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        MoveAction();
    }

    protected abstract void MoveAction();


    public void TakeDamage(float damage)
    {
        if (_isDead) return;
        _animator.SetTrigger(_animHit);
        _health -= damage;
        _damagedaudioSource.Play();
        if (_health <= 0)
        {
            _isDead = true;
            // 너죽자!
            ShowDeathEffect();
            ItemSpawn();
            ScoreManager.Instance.AddScore(100);
            Debug.Log("적 사망!!");
            Destroy(gameObject);
        }
    }

    private void ShowDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isDead) return;
        collision.gameObject.CompareTag("Player");
        Player player = collision.gameObject.GetComponent<Player>();
        if (player == null)
        {
            Debug.LogWarning("플레이어가 NULL 입니다.");
            return;
        }

        player.TakeDamage(_damage);
        Destroy(gameObject);
    }

    private void ItemSpawn()
    {
        float totalWeight = 0;
        foreach (ItemSpawnData data in _itemSpawnDataTable.Datas)
        {
            totalWeight += data.Weight;
        }

        float randomWeight = Random.value * totalWeight;

        foreach (ItemSpawnData data in _itemSpawnDataTable.Datas)
        {
            if (randomWeight < data.Weight)
            {
                Instantiate(data.ItemPrefab, transform.position, Quaternion.identity);
                break;
            }

            randomWeight -= data.Weight;
        }
    }
}