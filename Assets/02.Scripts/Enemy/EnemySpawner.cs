using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 필요 속성
    // - 타이머
    [Header("스폰 간격")]
    [SerializeField] private float _spawnInterval = 3f;

    [SerializeField] private EnemySpawnDataTableSO _spawnDataTable;

    private float _timer;

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
        int totalWeight = 0;
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            totalWeight += data.Weight;
        }

        int randomWeight = Random.Range(0, totalWeight);
        int cumulativeWeight = 0;
        // Todo: Scriptable Object를 사용해서 리펙토링
        // 이유 1: 배열을 사용했지만 각 아이템이 어떤 프리팹인지 알수가 없음
        // 이유 2: 각 에너미 스폰 확률을 매직 넘버로 하드코딩해서 유지보수가 어렵
        foreach (EnemySpawnData data in _spawnDataTable.Datas)
        {
            cumulativeWeight += data.Weight; // 누적
            if (randomWeight < cumulativeWeight) // 구간
            {
                GameObject enemy = Instantiate(data.EnemyPrefab);
                enemy.transform.position = transform.position;
                break;
            }
        }
    }
}