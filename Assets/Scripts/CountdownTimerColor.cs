using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimerColor : MonoBehaviour
{
    TextMeshProUGUI _countdownText;
    public float _countdownTimer;

    void Start()
    {
        _countdownText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (_countdownTimer > 0)
        {
            _countdownTimer -= Time.deltaTime;
            _countdownText.color = Color.white;
            
            _countdownText.text = (_countdownTimer+1).ToString().Substring(0, 1);
        }
        else
        {
            _countdownTimer = 0;
            _countdownText.color = new Color32(0, 0, 0, 0);
        }
    }
}
