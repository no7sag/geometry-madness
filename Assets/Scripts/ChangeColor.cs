using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip sonidocambio;
    Renderer _playerRenderer;
    GameObject _canvasCountdownColorText;
    [SerializeField] Material _whiteMaterial;
    [SerializeField] Material _redMaterial, _redGlassMaterial;
    [SerializeField] Material _blueMaterial, _blueGlassMaterial;
    [SerializeField] Material _greenMaterial, _greenGlassMaterial;
    float _colorDuration = 5.0f;
    float _colorDuration2 = 9.0f;

    void Awake()
    {
        _canvasCountdownColorText = GameObject.Find("Countdown Color Text");
    }

    void Start()
    {
        _playerRenderer = GameManager.Instance.player.GetComponent<Renderer>();
    }
    void Update()
    {
        if (GameManager.Instance.IsPaused())
            return;
        
        transform.Rotate(0, 0.45f, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (_canvasCountdownColorText.GetComponent<CountdownTimerColor>()._countdownTimer != 0)
        {
            GameObject[] colorPickups = GameObject.FindGameObjectsWithTag("ColorPickup");
            foreach (GameObject colorPickup in colorPickups)
            {
                colorPickup.GetComponent<ChangeColor>().StopCoroutine("ResetColorCountdown");
                colorPickup.GetComponent<ChangeColor>().StopCoroutine("ResetColorCountdown2");
            }
            audioManager.ReproducirSonido(sonidocambio, 0.52f);
        }

        Material pickupColor = gameObject.GetComponent<Renderer>().sharedMaterial;
        _playerRenderer.sharedMaterial = pickupColor;

        if (_playerRenderer.sharedMaterial == _redMaterial)
        {
            EnableRedColliders();
            DisableBlueColliders();
            DisableGreenColliders();
            _canvasCountdownColorText.GetComponent<CountdownTimerColor>()._countdownTimer = _colorDuration;
            StartCoroutine("ResetColorCountdown");

        }

        if (_playerRenderer.sharedMaterial == _blueMaterial)
        {
            EnableBlueColliders();
            DisableRedColliders();
            DisableGreenColliders();
            _canvasCountdownColorText.GetComponent<CountdownTimerColor>()._countdownTimer = _colorDuration;
            StartCoroutine("ResetColorCountdown");

        }

        if (_playerRenderer.sharedMaterial == _greenMaterial)
        {
            EnableGreenColliders();
            DisableBlueColliders();
            DisableRedColliders();
            _canvasCountdownColorText.GetComponent<CountdownTimerColor>()._countdownTimer = _colorDuration2;
            StartCoroutine("ResetColorCountdown2");
        }

        
    }

    void EnableRedColliders()
    {
        GameObject[] redColliders = GameObject.FindGameObjectsWithTag("RedCollider");
        foreach (GameObject redCollider in redColliders)
        {
            redCollider.GetComponent<Collider>().enabled = true;
            redCollider.GetComponent<Renderer>().material = _redMaterial;
        }
    }

    void EnableBlueColliders()
    {
        GameObject[] blueColliders = GameObject.FindGameObjectsWithTag("BlueCollider");
        foreach (GameObject blueCollider in blueColliders)
        {
            blueCollider.GetComponent<Collider>().enabled = true;
            blueCollider.GetComponent<Renderer>().material = _blueMaterial;
        }
    }
    void EnableGreenColliders()
    {
        GameObject[] greenColliders = GameObject.FindGameObjectsWithTag("GreenCollider");
        foreach (GameObject greenCollider in greenColliders)
        {
            greenCollider.GetComponent<Collider>().enabled = true;
            greenCollider.GetComponent<Renderer>().material = _greenMaterial;
        }
    }

    void DisableRedColliders()
    {
        GameObject[] redColliders = GameObject.FindGameObjectsWithTag("RedCollider");
        foreach (GameObject redCollider in redColliders)
        {
            redCollider.GetComponent<Collider>().enabled = false;
            redCollider.GetComponent<Renderer>().material = _redGlassMaterial;
        }
    }

    void DisableBlueColliders()
    {
        GameObject[] blueColliders = GameObject.FindGameObjectsWithTag("BlueCollider");
        foreach (GameObject blueCollider in blueColliders)
        {
            blueCollider.GetComponent<Collider>().enabled = false;
            blueCollider.GetComponent<Renderer>().material = _blueGlassMaterial;
        }
    }
    
     void DisableGreenColliders()
    {
        GameObject[] greenColliders = GameObject.FindGameObjectsWithTag("GreenCollider");
        foreach (GameObject greenCollider in greenColliders)
        {
            greenCollider.GetComponent<Collider>().enabled = false;
            greenCollider.GetComponent<Renderer>().material = _greenGlassMaterial;
        }
    }

    IEnumerator ResetColorCountdown()
    {
        yield return new WaitForSeconds(_colorDuration);
        _playerRenderer.sharedMaterial = _whiteMaterial;
        
        DisableRedColliders();
        DisableBlueColliders();
    }

    IEnumerator ResetColorCountdown2()
    {
        yield return new WaitForSeconds(_colorDuration2);
        _playerRenderer.sharedMaterial = _whiteMaterial;

        DisableGreenColliders();
    }
}
