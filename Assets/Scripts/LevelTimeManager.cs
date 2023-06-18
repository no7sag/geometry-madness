using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimeManager : MonoBehaviour
{
    public static LevelTimeManager Instance { get; private set; }
    float levelTimer;
    bool levelEnded;
    TextMeshProUGUI levelTimerText;
    int minutes, seconds, cents;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        levelTimerText = GameObject.Find("Level Timer").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!levelEnded)
        {
            levelTimer += Time.deltaTime;
        }
        else
        {
            if (PlayerPrefs.GetFloat(LevelTimeKey()) == 0)
            {
                PlayerPrefs.SetFloat(LevelTimeKey(), levelTimer);
                return;
            }
            
            if (PlayerPrefs.GetFloat(LevelTimeKey()) > levelTimer)
            {
                PlayerPrefs.SetFloat(LevelTimeKey(), levelTimer);
            }
        }

        levelTimerText.text = FormatTimer();
    }

    public void SetLevelEnded(bool active) => levelEnded = active;
    public string LevelTimeKey() => SceneManager.GetActiveScene().name + "--time";
    public string FormatTimer()
    {
        minutes = (int)(levelTimer / 60f);
        seconds = (int)(levelTimer - minutes * 60f);
        cents = (int)((levelTimer - (int)levelTimer) * 100f);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, cents);
    }
}
