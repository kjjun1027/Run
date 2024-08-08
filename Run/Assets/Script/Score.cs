using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수를 표시할 UI 텍스트
    private ScoreManager scoreManager; // ScoreManager 참조

    private void Start()
    {
        // ScoreManager 인스턴스 가져오기
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager != null)
        {
            // ScoreManager에 이 스크립트를 전달
            scoreManager.SetScore(this);
        }

        // 초기 점수 UI 업데이트
        UpdateScoreUI(scoreManager.GetScore());
    }

    // 점수 UI 업데이트 메서드
    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // 점수 초기화 UI 메서드
    public void ResetScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
    }

}
