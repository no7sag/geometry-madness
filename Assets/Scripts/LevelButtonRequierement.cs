using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonRequierement : MonoBehaviour
{
    Button _button;
    [SerializeField] string _previousLevelScene;

    void Awake()
    {
        _button = GetComponent<Button>();
    }
    void Start()
    {
        float _previousLevelTimer = PlayerPrefs.GetFloat(_previousLevelScene + "--time");

        if (_previousLevelTimer == 0)
            _button.interactable = false;
    }
}
