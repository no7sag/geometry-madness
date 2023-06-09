using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLevelMenu : MonoBehaviour
{
    [SerializeField] Animator _sceneTransitionAnim;
    Animator _animator;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        GameManager.Instance.TogglePause();
        GameManager.Instance.ToggleLosing();

        _animator = GetComponent<Animator>();
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    IEnumerator RestartLevelCoroutine()
    {
        _animator.SetTrigger("FadeOut");
        _sceneTransitionAnim.SetTrigger("Start");
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
        _sceneTransitionAnim.SetTrigger("Start");
        yield return new WaitForSeconds(0.9f);

        SceneManager.LoadScene("MainMenu");
    }
}
