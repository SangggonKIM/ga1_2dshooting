using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 싱글톤 패턴
    // 1. 전역적으로 접근 가능하다.
    // 2. 인스턴스(생성된 객체)가 하나임을 보장한다.
    public static ScoreManager Instance;
    // 관리: 특정 데이터에 대한 무결성과 추가 수정 삭제 등과 관련된 로직

    private int _bestScore = 0;

    private int _currentScore = 0;

    // UI 책임 추가 (텍스트메시 프로 참조)
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _currentScoreText;


    private void Awake()
    {
        Instance = this;
    }
    public int GetScore()
    {
        return _currentScore;
    }

    public void AddScore(int score)
    {
        if (score <= 0) return;
        _currentScore += score;
        if (_currentScore > _bestScore)
        {
            _bestScore = _currentScore;
        }
    }

    private void Update()
    {
        Refresh();
    }

    private void Refresh()
    {
        _bestScoreText.text = $"Best Score: {_bestScore}";
        _currentScoreText.text = $"Current Score: {_currentScore}";
    }
}