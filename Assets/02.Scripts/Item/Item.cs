using UnityEngine;

public class Item : MonoBehaviour
{
    public float SpawnTime = 1f;
    private float _currenttime = 0f;
    [SerializeField] private float _moveSpeed = 1f;
    private Vector2 _direction;
    private GameObject _player;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
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
