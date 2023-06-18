using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimeUI : MonoBehaviour
{
    TextMeshProUGUI textComponent;
    int minutes, seconds, cents;
    [SerializeField] string levelSceneName;
    
    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        if (PlayerPrefs.GetFloat(LevelTimeKey()) != 0)
            textComponent.text = FormatTimer();            
    }

    string LevelTimeKey() => levelSceneName + "--time";
    float LevelTimeValue() => PlayerPrefs.GetFloat(LevelTimeKey());
    string FormatTimer()
    {
        minutes = (int)(LevelTimeValue() / 60f);
        seconds = (int)(LevelTimeValue() - minutes * 60f);
        cents = (int)((LevelTimeValue() - (int)LevelTimeValue()) * 100f);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, cents);
    }
}
