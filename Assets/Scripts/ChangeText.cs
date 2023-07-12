using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    TextMeshProUGUI textComponent;
    [TextArea(2,3)]
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
