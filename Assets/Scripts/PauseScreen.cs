using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] GameObject _pauseScreenCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.IsLosing())
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
            Cursor.lockState = CursorLockMode.None;
            _pauseScreenCanvas.SetActive(true);
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
        GameManager.Instance.sceneTransitionAnim.SetTrigger("Start");
        Cursor.lockState = CursorLockMode.None;
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
        GameManager.Instance.sceneTransitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(0.9f);

        SceneManager.LoadScene("MainMenu");
    }

    void HidePauseMenu()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        _pauseScreenCanvas.SetActive(false);
    }
}
