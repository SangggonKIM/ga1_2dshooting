using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("아이템 목록 지정")][SerializeField] private GameObject[] _itemList;
    [SerializeField] private float[] _spawnProbability;
    [SerializeField] private float _damage = 30.0f;
    [SerializeField] private float _health = 100;
    [SerializeField] protected float _moveSpeed = 1.0f;
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
        _animator.SetTrigger(_animHit);
        _health -= damage;
        _damagedaudioSource.Play();
        if (_health <= 0)
        {
            // 너죽자!
            ShowDeathEffect();
            ItemSpawn();
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.AddScore(100);
            Destroy(gameObject);

        }
    }

    private void ShowDeathEffect()
    {
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        float total = 0;
        foreach (float probability in _spawnProbability)
        {
            total += probability;
        }

        float randomProbability = Random.value * total;

        for (int i = 0; i < _itemList.Length; i++)
        {
            if (randomProbability < _spawnProbability[i])
            {
                Instantiate(_itemList[i], transform.position, transform.rotation);
                break;
            }
            else
            {
                randomProbability -= _spawnProbability[i];
            }
        }
    }
}