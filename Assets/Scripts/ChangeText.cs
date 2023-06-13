using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    TextMeshProUGUI textComponent;
    [SerializeField] string spanishText;
    [SerializeField] int spanishFontSize;

    void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        if (PlayerPrefs.GetString("language") == "SPA")
        {
            textComponent.text = spanishText;

            if (spanishFontSize != 0)
                textComponent.fontSize = spanishFontSize;
        }
    }
}