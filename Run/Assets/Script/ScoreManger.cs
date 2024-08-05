using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    private int currentScore = 0;

    public void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    private void Awake()
    {
        // 싱글톤 인스턴스 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 이 오브젝트는 씬 전환 시 파괴되지 않음
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스가 있을 경우 파괴
        }
    }

    // 점수 추가 메서드
    public void AddScore(int scoreValue)
    {
        currentScore += scoreValue;
        UpdateScoreUI();
    }

    // 점수 UI 업데이트 메서드
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // 점수 초기화 메서드
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }
}