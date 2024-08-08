using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private Score score; // Score 참조
    private int currentScore = 0;

    private void Awake()
    {
        // 싱글톤 패턴 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 오브젝트를 유지
        }
        else
        {
            Destroy(gameObject); // 중복된 인스턴스가 있을 경우 파괴
        }
    }

    // ScoreDisplay 할당 메서드
    public void SetScore(Score scores)
    {
        score = scores;
    }

    // 점수 추가 메서드
    public void AddScore(int scoreValue)
    {
        currentScore += scoreValue;
        UpdateScoreDisplay();
    }

    // 점수 초기화 메서드
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreDisplay();
    }

    // 점수 업데이트 메서드
    private void UpdateScoreDisplay()
    {
        if (score != null)
        {
            score.UpdateScoreUI(currentScore);
        }
    }

    // 현재 점수 반환 메서드
    public int GetScore()
    {
        return currentScore;
    }
}