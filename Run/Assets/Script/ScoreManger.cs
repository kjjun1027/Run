using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private Score score; // Score ����
    private int currentScore = 0;

    private void Awake()
    {
        // �̱��� ���� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ������Ʈ�� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ��� ���� ��� �ı�
        }
    }

    // ScoreDisplay �Ҵ� �޼���
    public void SetScore(Score scores)
    {
        score = scores;
    }

    // ���� �߰� �޼���
    public void AddScore(int scoreValue)
    {
        currentScore += scoreValue;
        UpdateScoreDisplay();
    }

    // ���� �ʱ�ȭ �޼���
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreDisplay();
    }

    // ���� ������Ʈ �޼���
    private void UpdateScoreDisplay()
    {
        if (score != null)
        {
            score.UpdateScoreUI(currentScore);
        }
    }

    // ���� ���� ��ȯ �޼���
    public int GetScore()
    {
        return currentScore;
    }
}