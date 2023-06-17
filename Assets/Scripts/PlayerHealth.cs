using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Material _whiteMaterial, _whiteGlassMaterial;
    public int health;
    public int maxHealth = 2;
    float _immuneTimer;
    bool _recievedDamage;
    HealthMeter _healthMeter;


    void Awake()
    {
        health = maxHealth;
        _healthMeter = GameObject.Find("Health Meter").GetComponent<HealthMeter>();
    }

    void Update()
    {
        if (_recievedDamage)
        {
            if (_immuneTimer < GameManager.Instance.immuneDuration)
            {
                _immuneTimer += Time.deltaTime;
                GetComponent<Renderer>().sharedMaterial = _whiteGlassMaterial;
            }
            else
            {
                _recievedDamage = false;

                _immuneTimer = 0;
                GetComponent<Renderer>().sharedMaterial = _whiteMaterial;
            }
        }
    }

    public void Damage()
    {
        _recievedDamage = true;

        health--;

        _healthMeter.UpdateHealthMeter();

        if (health < 1)
        {
            GameManager.Instance.loseLevelScreen.SetActive(true);
        }
    }
}
