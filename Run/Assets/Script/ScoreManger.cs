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
        // �̱��� �ν��Ͻ� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ������Ʈ�� �� ��ȯ �� �ı����� ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� �ν��Ͻ��� ���� ��� �ı�
        }
    }

    // ���� �߰� �޼���
    public void AddScore(int scoreValue)
    {
        currentScore += scoreValue;
        UpdateScoreUI();
    }

    // ���� UI ������Ʈ �޼���
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // ���� �ʱ�ȭ �޼���
    public void ResetScore()
    {
        currentScore = 0;
        UpdateScoreUI();
    }
}