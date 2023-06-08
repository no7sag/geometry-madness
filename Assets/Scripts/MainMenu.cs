using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelSelectPanel;
    [SerializeField] Animator sceneTransitionAnim;

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

    /*
    public void ResetProgress()
    {
        PlayerPrefs.SetInt("completedLevels", 0);
        
        int levelCounter = 0;
        while (levelCounter < 8)
        {
            string levelScoreKey = "Level_" + (levelCounter + 1) + "_score";
            PlayerPrefs.SetInt(levelScoreKey, 0);
            levelCounter++;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    */
}
