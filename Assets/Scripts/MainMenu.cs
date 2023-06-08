using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelSelectPanel;
    [SerializeField] Animator sceneTransitionAnim;
    [SerializeField] float _xScrollRate, _yScrollRate;
    RawImage _bg;

    void Awake()
    {
        _bg = GetComponent<RawImage>();
    }

    void Update()
    {
        _bg = GetComponent<RawImage>();
        _bg.uvRect = new Rect(_bg.uvRect.position + new Vector2(_xScrollRate, _yScrollRate) * Time.deltaTime, _bg.uvRect.size);

    }
    public void PlayLevel(string levelName)
    {
        sceneTransitionAnim.SetTrigger("Start");

        SceneManager.LoadScene(levelName);
    }

    public void ShowLevelSelect()
    {
        if (!levelSelectPanel.activeSelf)
        {
            levelSelectPanel.SetActive(true);
        }
    }

    public void HideLevelSelect()
    {
        if (levelSelectPanel.activeSelf)
        {
            levelSelectPanel.SetActive(false);
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }


}
