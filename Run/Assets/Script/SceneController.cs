using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // 싱글톤 패턴을 사용하여 어디서든 접근 가능하게 함
    public static SceneController Instance;

    private void Awake()
    {
        // 싱글톤 인스턴스 초기화
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 삭제되지 않도록 설정
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 씬 로드 메서드
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 현재 씬을 다시 로드하는 메서드
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // 다음 씬을 로드하는 메서드 (씬 순서를 사전에 지정했을 때)
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // 특정 씬을 인덱스로 로드하는 메서드
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    // 타이틀 씬으로 돌아가는 메서드
    public void LoadTitleScene()
    {
        LoadScene("TitleScene"); // "TitleScene"은 타이틀 씬의 이름
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