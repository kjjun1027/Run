using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    // 메인 스테이지 및 서브 스테이지 선택 화면
    public GameObject mainMenu; // 메인 스테이지 선택 화면
    public GameObject stage1Menu; // 스테이지 1 서브 스테이지 선택 화면
    public GameObject stage2Menu; // 스테이지 2 서브 스테이지 선택 화면
    public GameObject stage3Menu; // 스테이지 3 서브 스테이지 선택 화면

    // 메인 스테이지 버튼
    public Button tutorialButton;
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;

    // 스테이지 1 서브 스테이지 버튼
    public Button stage1_1Button;
    public Button stage1_2Button;
    public Button stage1_3Button;

    // 스테이지 2 서브 스테이지 버튼
    public Button stage2_1Button;
    public Button stage2_2Button;
    public Button stage2_3Button;

    // 스테이지 3 서브 스테이지 버튼
    public Button stage3_1Button;
    public Button stage3_2Button;
    public Button stage3_3Button;

    private void Start()
    {
        // 스테이지 상태를 불러오기
        GameRuleController.Instance.LoadAllStagesClearStatus();

        // 각 메뉴 업데이트
        UpdateMainMenu();
        UpdateStage1Menu();
        UpdateStage2Menu();
        UpdateStage3Menu();
    }

    // 각 메뉴 업데이트
    void UpdateMainMenu()
    {
        tutorialButton.interactable = true;
        stage1Button.interactable = true;
        stage2Button.interactable = true;
        stage3Button.interactable = true;
    }

    void UpdateStage1Menu()
    {
        stage1_1Button.interactable = true; // 첫 번째 서브 스테이지는 항상 선택 가능
        stage1_2Button.interactable = GameRuleController.Instance.GetStageClearStatus("1-1");
        stage1_3Button.interactable = GameRuleController.Instance.GetStageClearStatus("1-2");
    }

    void UpdateStage2Menu()
    {
        stage2_1Button.interactable = true; // 첫 번째 서브 스테이지는 항상 선택 가능
        stage2_2Button.interactable = GameRuleController.Instance.GetStageClearStatus("2-1");
        stage2_3Button.interactable = GameRuleController.Instance.GetStageClearStatus("2-2");
    }

    void UpdateStage3Menu()
    {
        stage3_1Button.interactable = true; // 첫 번째 서브 스테이지는 항상 선택 가능
        stage3_2Button.interactable = GameRuleController.Instance.GetStageClearStatus("3-1");
        stage3_3Button.interactable = GameRuleController.Instance.GetStageClearStatus("3-2");
    }

    // 스테이지 버튼 클릭 시 호출되는 메서드
    public void OnTutorialButtonClicked()
    {
        OnStageButtonClicked("Tutorial");
    }

    public void OnStage1ButtonClicked()
    {
        mainMenu.SetActive(false);
        stage1Menu.SetActive(true);
    }

    public void OnStage2ButtonClicked()
    {
        mainMenu.SetActive(false);
        stage2Menu.SetActive(true);
    }

    public void OnStage3ButtonClicked()
    {
        mainMenu.SetActive(false);
        stage3Menu.SetActive(true);
    }

    // 서브 스테이지 버튼 클릭 시 호출되는 메서드
    public void OnStage1_1ButtonClicked() => OnStageButtonClicked("1-1");
    public void OnStage1_2ButtonClicked() => OnStageButtonClicked("1-2");
    public void OnStage1_3ButtonClicked() => OnStageButtonClicked("1-3");

    public void OnStage2_1ButtonClicked() => OnStageButtonClicked("2-1");
    public void OnStage2_2ButtonClicked() => OnStageButtonClicked("2-2");
    public void OnStage2_3ButtonClicked() => OnStageButtonClicked("2-3");

    public void OnStage3_1ButtonClicked() => OnStageButtonClicked("3-1");
    public void OnStage3_2ButtonClicked() => OnStageButtonClicked("3-2");
    public void OnStage3_3ButtonClicked() => OnStageButtonClicked("3-3");

    // 공통 스테이지 버튼 클릭 처리 메서드
    private void OnStageButtonClicked(string stageName)
    {
        PlayerPrefs.SetString("SelectedStage", stageName); // 선택한 스테이지 이름 저장
        PlayerPrefs.Save();
        SceneManager.LoadScene("StageScene"); // StageScene 로드
    }

    // 뒤로 가기 버튼 클릭 시 메인 메뉴로 돌아가기
    public void OnBackButtonClicked()
    {
        stage1Menu.SetActive(false);
        stage2Menu.SetActive(false);
        stage3Menu.SetActive(false);
        mainMenu.SetActive(true);
    }
}