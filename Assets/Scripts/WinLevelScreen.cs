using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevelScreen : MonoBehaviour
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
        GameManager.Instance.player.GetComponent<Animator>().SetTrigger("Winning");
    }

    public void NextLevel(string levelName)
    {
        StartCoroutine(NextLevelCoroutine(levelName));
    }

    IEnumerator NextLevelCoroutine(string levelName)
    {
        _animator.SetTrigger("FadeOut");
        GameManager.Instance.sceneTransitionAnim.SetTrigger("Start");
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(0.9f);

        SceneManager.LoadScene(levelName);
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
