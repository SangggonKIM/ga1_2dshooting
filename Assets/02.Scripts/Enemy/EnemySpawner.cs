using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [Header("스폰 간격")][SerializeField] private float _spawnInterval = 3f;
    private float _timer;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private int[] _chances;

    // - 생성할 프리팹
    [Header("스폰할 적 프리팹")][SerializeField] private Enemy _enemyPrefab;

    private void Start()
    {
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _timer = 0;

            _spawnInterval = Random.Range(1f, 3f);

            Spawn();
        }
    }

    private void Spawn()
    {
        int totalChances = 0;
        foreach (int i in _chances)
        {
            totalChances += i;
        }
        int randomValue = Random.Range(0, totalChances);
        int chanceSum = 0;
        // Todo: Scriptable Object를 사용해서 리펙토링
        // 이유 1: 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알수가 없음
        // 이유 2: 각 에너미 스폰 확률을 매직 넘버로 하드코딩해서 유지보수가 어렵
        for (int i = 0; i < _enemies.Length; i++)
        {
            chanceSum += _chances[i];
            if (randomValue < chanceSum)
            {
                Enemy enemy = Instantiate(_enemies[i]);
                enemy.transform.position = transform.position;
                break;
            }
        }
    }
}