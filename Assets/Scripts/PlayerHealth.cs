using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Material _whiteMaterial, _whiteGlassMaterial;
    public int health;
    public int maxHealth = 2;
    float immuneTimer;
    bool recievedDamage;

    void Awake()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (recievedDamage)
        {
            if (immuneTimer < GameManager.Instance.immuneDuration)
            {
                immuneTimer += Time.deltaTime;
                GetComponent<Renderer>().sharedMaterial = _whiteGlassMaterial;
            }
            else
            {
                immuneTimer = 0;
                recievedDamage = false;
                GetComponent<Renderer>().sharedMaterial = _whiteMaterial;
            }
        }
    }

    public void Damage()
    {
        health--;
        recievedDamage = true;

        if (health < 1)
        {
            GameManager.Instance.loseLevelScreen.SetActive(true);
        }
    }
}
