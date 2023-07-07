using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimeUI : MonoBehaviour
{
    TextMeshProUGUI _textComponent;
    [SerializeField] string _levelSceneName;
    
    void Awake()
    {
        _textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        string levelTimeKey = _levelSceneName + "--time";
        float levelTimeValue = PlayerPrefs.GetFloat(levelTimeKey);

        if (PlayerPrefs.GetFloat(levelTimeKey) != 0)
            _textComponent.text = LevelTimeManager.Instance.FormatTimer(levelTimeValue);  
    }
}
