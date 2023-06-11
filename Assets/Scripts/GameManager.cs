using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    bool isPaused, isLosing;
    public GameObject loseLevelScreen, player;
    public enum Language { ENG, SPA };
    public Language language;


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
    }

    public bool IsPaused() => isPaused;
    public void TogglePause() => isPaused = !isPaused;
    public bool IsLosing() => isLosing;
    public void ToggleLosing()
    {
        isLosing = !isLosing;
        player.GetComponent<Animator>().enabled = true;
    }
}
