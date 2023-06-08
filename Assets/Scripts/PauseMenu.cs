using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseScreenCanvas;
    [SerializeField] Animator sceneTransitionAnim;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPauseScreen();
        }
    }

    void ShowPauseScreen()
    {
        GameManager.Instance.TogglePause();

        if (GameManager.Instance.IsPaused())
        {
            Time.timeScale = 0.0f;
            pauseScreenCanvas.SetActive(true);
        }
        else
        {
            HidePauseMenu();
        }
    }

    public void Resume()
    {
        GameManager.Instance.TogglePause();

        HidePauseMenu();
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());

        HidePauseMenu();
    }

    IEnumerator RestartLevelCoroutine()
    {
        sceneTransitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(0.9f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        GameManager.Instance.TogglePause();
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuCoroutine());

        HidePauseMenu();
    }

    IEnumerator MainMenuCoroutine()
    {
        sceneTransitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(0.9f);

        SceneManager.LoadScene("MainMenu");

        GameManager.Instance.TogglePause();
    }

    void HidePauseMenu()
    {
        Time.timeScale = 1.0f;
        pauseScreenCanvas.SetActive(false);
    }
}
