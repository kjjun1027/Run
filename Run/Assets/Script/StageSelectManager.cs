using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    // ���� �������� �� ���� �������� ���� ȭ��
    public GameObject mainMenu; // ���� �������� ���� ȭ��
    public GameObject stage1Menu; // �������� 1 ���� �������� ���� ȭ��
    public GameObject stage2Menu; // �������� 2 ���� �������� ���� ȭ��
    public GameObject stage3Menu; // �������� 3 ���� �������� ���� ȭ��

    // ���� �������� ��ư
    public Button tutorialButton;
    public Button stage1Button;
    public Button stage2Button;
    public Button stage3Button;

    // �������� 1 ���� �������� ��ư
    public Button stage1_1Button;
    public Button stage1_2Button;
    public Button stage1_3Button;

    // �������� 2 ���� �������� ��ư
    public Button stage2_1Button;
    public Button stage2_2Button;
    public Button stage2_3Button;

    // �������� 3 ���� �������� ��ư
    public Button stage3_1Button;
    public Button stage3_2Button;
    public Button stage3_3Button;

    private void Start()
    {
        // �������� ���¸� �ҷ�����
        GameRuleController.Instance.LoadAllStagesClearStatus();

        // �� �޴� ������Ʈ
        UpdateMainMenu();
        UpdateStage1Menu();
        UpdateStage2Menu();
        UpdateStage3Menu();
    }

    // �� �޴� ������Ʈ
    void UpdateMainMenu()
    {
        tutorialButton.interactable = true;
        stage1Button.interactable = true;
        stage2Button.interactable = true;
        stage3Button.interactable = true;
    }

    void UpdateStage1Menu()
    {
        stage1_1Button.interactable = true; // ù ��° ���� ���������� �׻� ���� ����
        stage1_2Button.interactable = GameRuleController.Instance.GetStageClearStatus("1-1");
        stage1_3Button.interactable = GameRuleController.Instance.GetStageClearStatus("1-2");
    }

    void UpdateStage2Menu()
    {
        stage2_1Button.interactable = true; // ù ��° ���� ���������� �׻� ���� ����
        stage2_2Button.interactable = GameRuleController.Instance.GetStageClearStatus("2-1");
        stage2_3Button.interactable = GameRuleController.Instance.GetStageClearStatus("2-2");
    }

    void UpdateStage3Menu()
    {
        stage3_1Button.interactable = true; // ù ��° ���� ���������� �׻� ���� ����
        stage3_2Button.interactable = GameRuleController.Instance.GetStageClearStatus("3-1");
        stage3_3Button.interactable = GameRuleController.Instance.GetStageClearStatus("3-2");
    }

    // �������� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
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

    // ���� �������� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    public void OnStage1_1ButtonClicked() => OnStageButtonClicked("1-1");
    public void OnStage1_2ButtonClicked() => OnStageButtonClicked("1-2");
    public void OnStage1_3ButtonClicked() => OnStageButtonClicked("1-3");

    public void OnStage2_1ButtonClicked() => OnStageButtonClicked("2-1");
    public void OnStage2_2ButtonClicked() => OnStageButtonClicked("2-2");
    public void OnStage2_3ButtonClicked() => OnStageButtonClicked("2-3");

    public void OnStage3_1ButtonClicked() => OnStageButtonClicked("3-1");
    public void OnStage3_2ButtonClicked() => OnStageButtonClicked("3-2");
    public void OnStage3_3ButtonClicked() => OnStageButtonClicked("3-3");

    // ���� �������� ��ư Ŭ�� ó�� �޼���
    private void OnStageButtonClicked(string stageName)
    {
        PlayerPrefs.SetString("SelectedStage", stageName); // ������ �������� �̸� ����
        PlayerPrefs.Save();
        SceneManager.LoadScene("StageScene"); // StageScene �ε�
    }

    // �ڷ� ���� ��ư Ŭ�� �� ���� �޴��� ���ư���
    public void OnBackButtonClicked()
    {
        stage1Menu.SetActive(false);
        stage2Menu.SetActive(false);
        stage3Menu.SetActive(false);
        mainMenu.SetActive(true);
    }
}