// 데이터 클래스: 순수하게 데이터(값)를 보관하고  전달하는 목적으로 만든 특수한 클래스.

using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _weight;
    public GameObject EnemyPrefab => _enemyPrefab;
    public int Weight => _weight;
}