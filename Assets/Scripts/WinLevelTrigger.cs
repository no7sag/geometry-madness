using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.winLevelScreen.SetActive(true);
            LevelTimeManager.Instance.SetLevelEnded(true);
        }
    }
}
