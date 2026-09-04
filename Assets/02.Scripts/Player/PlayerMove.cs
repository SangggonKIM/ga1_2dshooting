using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 목적: 키보드 입력에 따라서 플레이어 이동 처리를 하고 싶다.
    // 필요 필드:
    public float IncreaseSpeed = 1.0f;
    public float Speed;
    public float DecreaseSpeed = -1.0f;
    [SerializeField] private float _health = 100.0f;
    [SerializeField] private Vector2 _xBound = new Vector2(1.85f, 0); // x축 이동 제한 범위
    private Vector2 _xMoveOhterside = new Vector2(2.91f, 0); // x축 화면 넘어갈시 반대쪽 이동
    private Vector2 _yTopBound = new Vector2(0, -0.7f); // y축 위쪽 이동 제한 범위
    private Vector2 _yBottomBound = new Vector2(0, -4.72f); // y축 위쪽 이동 제한 범위


    // 매 프레임마다 실행된다.
    // 초당 프레임 실행 횟수는: 별다른 설정이 없을 경우 가능한 많이

    private void Update()
    {
        Move();

        SpeedChange();
    }

    private void Move()
    {
        // 1. 키보드 입력을 받는다.
        float h = Input.GetAxis("Horizontal"); // 키보드 왼/오른쪽 입력 상태에 따라 -1f ~ 0 ~ 1f
        float v = Input.GetAxis("Vertical"); //키보드 위/아래 입력 상태에 따라 -1f ~ 0 ~ 1f


        // 2. 키보드 입력에 따라 방향을 구한다.
        // 게임에는 벡터라는 타입이 있다. 벡터는(크기와 방향을 의미한다)
        Vector2 direction = new Vector2(h, v); // 왼쪽 방향
        // = Vector2 direction = Vector2.left;


        // 3. 방향과 속도에 따라 이동한다.
        // 속도 = 방향 * 속력
        //transform.Translate(direction * Speed * Time.deltaTime);
        // 매직 넘버란: 마법처럼 보는 사람마다 의미가 달라질 수 있는
        // 헷갈리는 숫자 코드에 사용 가능한 숫자는 0, 1 만
        // Speed = 0.06f
        // deltaTime: 이전 프레임으로부터 지금 프레임까지 시간이 얼마나 지났는지 MS로 반환


        Vector2 normalizedDirection = direction.normalized; // 벡터의 길이를 1로 만들어주는것 ( 즉, 방향만 유지한다.)
        transform.Translate(normalizedDirection * Speed * Time.deltaTime);
        Vector2 playerPosition = transform.position;
        if (playerPosition.x > _xMoveOhterside.x)
        {
            playerPosition.x = -_xMoveOhterside.x;
        }
        else if (playerPosition.x < -_xMoveOhterside.x)
        {
            playerPosition.x = _xMoveOhterside.x;
        }

        if (playerPosition.y > _yTopBound.y)
        {
            playerPosition.y = _yTopBound.y;
        }
        else if (playerPosition.y < _yBottomBound.y)
        {
            playerPosition.y = _yBottomBound.y;
        }

        transform.position = playerPosition;

        // 새로운 위치 = 현재 위치 + (방향 * 속력 * 시간)
        // transform.position += (Vector3)direction * Speed * Time.deltaTime;
    }

    public void SpeedChange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Speed += IncreaseSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Speed += DecreaseSpeed;
            if (Speed <= 0)
            {
                Speed += IncreaseSpeed;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}