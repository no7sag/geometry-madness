using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelTimeManager : MonoBehaviour
{
    public static LevelTimeManager Instance { get; private set; }
    [SerializeField] GameObject levelTimerObject;
    TextMeshProUGUI levelTimerText;
    float levelTimer;
    bool levelEnded;
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

        if (levelTimerObject != null)
            levelTimerText = levelTimerObject.GetComponent<TextMeshProUGUI>();
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

        if (levelTimerObject != null)
            levelTimerText.text = FormatTimer(levelTimer);
    }

    public void SetLevelEnded(bool active) => levelEnded = active;
    public string LevelTimeKey() => SceneManager.GetActiveScene().name + "--time";
    public string FormatTimer(float levelTimerRaw)
    {
        minutes = (int)(levelTimerRaw / 60f);
        seconds = (int)(levelTimerRaw - minutes * 60f);
        cents = (int)((levelTimerRaw - (int)levelTimerRaw) * 100f);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, cents);
    }
}
