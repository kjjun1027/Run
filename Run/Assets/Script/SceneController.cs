using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // �̱��� ������ ����Ͽ� ��𼭵� ���� �����ϰ� ��
    public static SceneController Instance;

    private void Awake()
    {
        // �̱��� �ν��Ͻ� �ʱ�ȭ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� �������� �ʵ��� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �� �ε� �޼���
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ���� ���� �ٽ� �ε��ϴ� �޼���
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ���� ���� �ε��ϴ� �޼��� (�� ������ ������ �������� ��)
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Ư�� ���� �ε����� �ε��ϴ� �޼���
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // Ÿ��Ʋ ������ ���ư��� �޼���
    public void LoadTitleScene()
    {
        LoadScene("TitleScene"); // "TitleScene"�� Ÿ��Ʋ ���� �̸�
    }

    public void OnStartButtonClick()
    {
        Instance.LoadScene("StageSelectScene");
    }

    public void OnStage1ButtonClick()
    {
        LoadScene("Stage1Scene");
    }
}