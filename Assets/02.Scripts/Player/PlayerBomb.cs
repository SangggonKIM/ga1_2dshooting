using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    [SerializeField] private GameObject _bomb;
    [SerializeField] private float _coolTime = 10f;
    [SerializeField] private Transform _bombPosition;
    private float _coolTimer = 0;
    private void Start()
    {
        _coolTimer = _coolTime;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            Bomb();
        }
    }

    private void Bomb()
    {
        _coolTimer -= Time.deltaTime;
        if (_coolTimer <= 0)
        {
            Instantiate(_bomb, _bombPosition.position, Quaternion.identity);
            _coolTimer = _coolTime;
        }
    }
}
