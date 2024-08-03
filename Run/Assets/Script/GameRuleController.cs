using UnityEngine;
using UnityEngine.UI;

public class GameRuleController : MonoBehaviour
{
    public static GameRuleController Instance;

    public GameObject darkOverlay;
    public GameObject gameRulesPanel;

    // 스테이지 클리어 상태 변수들
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

    // 게임 룰을 보여주는 메서드
    public void ShowGameRules()
    {
        darkOverlay.SetActive(true);
        gameRulesPanel.SetActive(true);
    }

    // 게임 룰을 닫는 메서드
    public void HideGameRules()
    {
        darkOverlay.SetActive(false);
        gameRulesPanel.SetActive(false);
    }

    // 스테이지 클리어 상태를 설정하는 메서드
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

    // 모든 스테이지 클리어 상태를 저장하는 메서드
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

    // 각 스테이지의 클리어 상태를 반환하는 메서드
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



    // 게임을 종료하거나 메인 메뉴로 돌아가는 메서드
    public void ExitGame()
    {
        Application.Quit(); // 애플리케이션 종료

        // 또는 메인 메뉴로 돌아가는 씬 전환
        // SceneManager.LoadScene("MainMenuScene");

        Debug.Log("Game Exited");
    }
}