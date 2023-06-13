using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLevelScreen : MonoBehaviour
{
    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.None;
    }

    void Start()
    {
        GameManager.Instance.TogglePause();
        GameManager.Instance.ToggleLosing();
        GameManager.Instance.player.GetComponent<Animator>().enabled = true;
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    IEnumerator RestartLevelCoroutine()
    {
        _animator.SetTrigger("FadeOut");
        GameManager.Instance.sceneTransitionAnim.SetTrigger("Start");
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(0.9f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        StartCoroutine(MainMenuCoroutine());
    }

    IEnumerator MainMenuCoroutine()
    {
        _animator.SetTrigger("FadeOut");
        GameManager.Instance.sceneTransitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(0.9f);

        SceneManager.LoadScene("MainMenu");
    }
}
