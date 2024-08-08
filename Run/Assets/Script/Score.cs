using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ ǥ���� UI �ؽ�Ʈ
    private ScoreManager scoreManager; // ScoreManager ����

    private void Start()
    {
        // ScoreManager �ν��Ͻ� ��������
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager != null)
        {
            // ScoreManager�� �� ��ũ��Ʈ�� ����
            scoreManager.SetScore(this);
        }

        // �ʱ� ���� UI ������Ʈ
        UpdateScoreUI(scoreManager.GetScore());
    }

    // ���� UI ������Ʈ �޼���
    public void UpdateScoreUI(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // ���� �ʱ�ȭ UI �޼���
    public void ResetScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
    }

}
