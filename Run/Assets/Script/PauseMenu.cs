using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;

    private bool isPaused = false;

    public void Start()
    {
        pauseMenuUI.SetActive(false);
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StageSelectScene"); // 메인 메뉴 씬으로 돌아가기
    }
}