using UnityEngine;

public class Item : MonoBehaviour
{
    public float SpawnTime = 1f;
    private float _currenttime = 0f;
    [SerializeField] private float _moveSpeed = 1f;
    private Vector2 _direction;
    private Player _player = null;
    [SerializeField] protected float _value;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogWarning("플레이어를 찾을 수 없습니다.");
            return;
        }
    }

    private void Update()
    {
        _currenttime += Time.deltaTime;
        if (_currenttime >= SpawnTime)
        {
            _direction = _player.transform.position - transform.position;
            _direction.Normalize();
            transform.Translate(_direction * _moveSpeed * Time.deltaTime);
        }
    }
}
