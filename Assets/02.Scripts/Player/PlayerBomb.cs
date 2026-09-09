using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;
    [SerializeField] private float _coolTime = 10f;
    [SerializeField] private int _spawnNumber = 3;
    [SerializeField] private float _bombXRange = 2.5f;
    [SerializeField] private float _bombYMaxRange = 5.0f;
    [SerializeField] private float _bombYMinRange;
    private float _coolTimer = 0;
    private void Start()
    {
        _coolTimer = _coolTime;
    }

    private void Update()
    {
        Bomb();
    }

    private void Bomb()
    {
        _coolTimer -= Time.deltaTime;
        if (_coolTimer <= 0)
        {
            if (Input.GetKey(KeyCode.B))
            {
                for (int i = 0; i < _spawnNumber; i++)
                {
                    Vector2 bombPosition = new Vector2(Random.Range(-_bombXRange, _bombXRange), Random.Range(_bombYMinRange, _bombYMaxRange));
                    Instantiate(_bomb, bombPosition, Quaternion.identity);
                }
                _coolTimer = _coolTime;
            }
        }
    }
}
