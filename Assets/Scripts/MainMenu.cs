using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _levelSelectPanel;
    [SerializeField] float _xScrollRate, _yScrollRate;
    RawImage _bg;
    ChangeText changeText;

    void Awake()
    {
        _bg = GetComponent<RawImage>();

        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        _bg = GetComponent<RawImage>();
        _bg.uvRect = new Rect(_bg.uvRect.position + new Vector2(_xScrollRate, _yScrollRate) * Time.deltaTime, _bg.uvRect.size);
    }

    public void PlayLevel(string levelName)
    {
        StartCoroutine(PlayLevelCoroutine(levelName));
    }

    IEnumerator PlayLevelCoroutine(string levelName)
    {
        GameManager.Instance.sceneTransitionAnim.SetTrigger("Start");
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(0.9f);
        
        SceneManager.LoadScene(levelName);
    }

    public void ShowLevelSelect()
    {
        if (!_levelSelectPanel.activeSelf)
        {
            _levelSelectPanel.SetActive(true);
        }
    }

    public void HideLevelSelect()
    {
        if (_levelSelectPanel.activeSelf)
        {
            _levelSelectPanel.SetActive(false);
        }
    }

    // public void ChangeLanguage()
    // {
    //     if (PlayerPrefs.GetString("language") == "ENG")
    //     {
    //         PlayerPrefs.SetString("language", "SPA");
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //         return;
    //     }

    //     if (PlayerPrefs.GetString("language") == "SPA")
    //     {
    //         PlayerPrefs.SetString("language", "ENG");
    //         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //         return;
    //     }
    // }

    public void ChangeLanguage()
    {
        StartCoroutine(ChangeLanguageCoroutine());
    }

    IEnumerator ChangeLanguageCoroutine()
    {
        GameManager.Instance.sceneTransitionAnim.SetTrigger("Start");
        Cursor.lockState = CursorLockMode.None;
        yield return new WaitForSeconds(0.9f);
        
        if (PlayerPrefs.GetString("language") == "ENG")
        {
            PlayerPrefs.SetString("language", "SPA");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            yield return null;
        }

        if (PlayerPrefs.GetString("language") == "SPA")
        {
            PlayerPrefs.SetString("language", "ENG");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            yield return null;
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
