using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMeter : MonoBehaviour
{
    [SerializeField] GameObject[] _heartImages;
    [SerializeField] Sprite _emptyHeartImage;

    public void UpdateHealthMeter()
    {
        int heartSlot = GameManager.Instance.player.GetComponent<PlayerHealth>().health;
        
        if (heartSlot > 0)
            _heartImages[^heartSlot].GetComponent<Image>().sprite = _emptyHeartImage;
        else
            _heartImages[0].GetComponent<Image>().sprite = _emptyHeartImage;
    }
}
