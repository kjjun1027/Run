using UnityEngine;
using UnityEngine.UI;

public class GameRuleController : MonoBehaviour
{
    public static GameRuleController Instance;

    public GameObject darkOverlay;
    public GameObject gameRulesPanel;

    // �������� Ŭ���� ���� ������
    private bool tutorialCleared;
    private bool stage1_1Cleared;
    private bool stage1_2Cleared;
    private bool stage1_3Cleared;
    private bool stage2_1Cleared;
    private bool stage2_2Cleared;
    private bool stage2_3Cleared;
    private bool stage3_1Cleared;
    private bool stage3_2Cleared;
    private bool stage3_3Cleared;

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

    // ���� ���� �����ִ� �޼���
    public void ShowGameRules()
    {
        darkOverlay.SetActive(true);
        gameRulesPanel.SetActive(true);
    }

    // ���� ���� �ݴ� �޼���
    public void HideGameRules()
    {
        darkOverlay.SetActive(false);
        gameRulesPanel.SetActive(false);
    }

    // �������� Ŭ���� ���¸� �����ϴ� �޼���
    public void SetStageClearStatus(string stageName, bool isCleared)
    {
        switch (stageName)
        {
            case "Tutorial":
                tutorialCleared = isCleared;
                break;
            case "1-1":
                stage1_1Cleared = isCleared;
                break;
            case "1-2":
                stage1_2Cleared = isCleared;
                break;
            case "1-3":
                stage1_3Cleared = isCleared;
                break;
            case "2-1":
                stage2_1Cleared = isCleared;
                break;
            case "2-2":
                stage2_2Cleared = isCleared;
                break;
            case "2-3":
                stage2_3Cleared = isCleared;
                break;
            case "3-1":
                stage3_1Cleared = isCleared;
                break;
            case "3-2":
                stage3_2Cleared = isCleared;
                break;
            case "3-3":
                stage3_3Cleared = isCleared;
                break;
            default:
                Debug.LogWarning("Invalid stage name.");
                break;
        }
    }

    // ��� �������� Ŭ���� ���¸� �����ϴ� �޼���
    public void SaveAllStagesClearStatus()
    {
        string[] stages = { "Tutorial", "1-1", "1-2", "1-3", "2-1", "2-2", "2-3", "3-1", "3-2", "3-3" };
        foreach (var stage in stages)
        {
            bool isCleared = GetStageClearStatus(stage);
            PlayerPrefs.SetInt($"{stage}_Clear", isCleared ? 1 : 0);
        }
        PlayerPrefs.Save();
        Debug.Log("All stages clear status saved.");
    }

    public void LoadAllStagesClearStatus()
    {
        string[] stages = { "Tutorial", "1-1", "1-2", "1-3", "2-1", "2-2", "2-3", "3-1", "3-2", "3-3" };
        foreach (var stage in stages)
        {
            bool isCleared = PlayerPrefs.GetInt($"{stage}_Clear", 0) == 1;
            SetStageClearStatus(stage, isCleared);
        }

        Debug.Log("Stage statuses loaded.");
    }

    // �� ���������� Ŭ���� ���¸� ��ȯ�ϴ� �޼���
    public bool GetStageClearStatus(string stageName)
    {
        switch (stageName)
        {
            case "Tutorial":
                return tutorialCleared;
            case "1-1":
                return stage1_1Cleared;
            case "1-2":
                return stage1_2Cleared;
            case "1-3":
                return stage1_3Cleared;
            case "2-1":
                return stage2_1Cleared;
            case "2-2":
                return stage2_2Cleared;
            case "2-3":
                return stage2_3Cleared;
            case "3-1":
                return stage3_1Cleared;
            case "3-2":
                return stage3_2Cleared;
            case "3-3":
                return stage3_3Cleared;
            default:
                Debug.LogWarning("Invalid stage name.");
                return false;
        }
    }



    // ������ �����ϰų� ���� �޴��� ���ư��� �޼���
    public void ExitGame()
    {
        Application.Quit(); // ���ø����̼� ����

        // �Ǵ� ���� �޴��� ���ư��� �� ��ȯ
        // SceneManager.LoadScene("MainMenuScene");

        Debug.Log("Game Exited");
    }
}