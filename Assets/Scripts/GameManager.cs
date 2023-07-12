using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    bool isPaused, isLosing;
    public GameObject player, winLevelScreen, loseLevelScreen;
    public Animator sceneTransitionAnim;
    public float immuneDuration = 2f;

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

        Cursor.lockState = CursorLockMode.Locked;

        if (!PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.SetString("language", "ENG");
        }
    }

    public bool IsPaused() => isPaused;
    public void TogglePause() => isPaused = !isPaused;
    public bool IsLosing() => isLosing;
    public void ToggleLosing() => isLosing = !isLosing;
}
