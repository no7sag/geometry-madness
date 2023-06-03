using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] GameObject _player, _canvasCountdownColorText;
    [SerializeField] Material _whiteMaterial;
    [SerializeField] Material _redMaterial, _redGlassMaterial;
    [SerializeField] Material _blueMaterial, _blueGlassMaterial;
    float _colorDuration = 5.0f;

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
            }
        }

        Material pickupColor = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
        _player.GetComponent<MeshRenderer>().sharedMaterial = pickupColor;

        if (_player.GetComponent<MeshRenderer>().sharedMaterial == _redMaterial)
        {
            EnableRedColliders();
            DisableBlueColliders();
        }

        if (_player.GetComponent<MeshRenderer>().sharedMaterial == _blueMaterial)
        {
            EnableBlueColliders();
            DisableRedColliders();
        }

        _canvasCountdownColorText.GetComponent<CountdownTimerColor>()._countdownTimer = _colorDuration;
        StartCoroutine("ResetColorCountdown");
    }

    void EnableRedColliders()
    {
        GameObject[] redColliders = GameObject.FindGameObjectsWithTag("RedCollider");
        foreach (GameObject redCollider in redColliders)
        {
            redCollider.GetComponent<Collider>().enabled = true;
            redCollider.GetComponent<MeshRenderer>().material = _redMaterial;
        }
    }

    void EnableBlueColliders()
    {
        GameObject[] blueColliders = GameObject.FindGameObjectsWithTag("BlueCollider");
        foreach (GameObject blueCollider in blueColliders)
        {
            blueCollider.GetComponent<Collider>().enabled = true;
            blueCollider.GetComponent<MeshRenderer>().material = _blueMaterial;
        }
    }

    void DisableRedColliders()
    {
        GameObject[] redColliders = GameObject.FindGameObjectsWithTag("RedCollider");
        foreach (GameObject redCollider in redColliders)
        {
            redCollider.GetComponent<Collider>().enabled = false;
            redCollider.GetComponent<MeshRenderer>().material = _redGlassMaterial;
        }
    }

    void DisableBlueColliders()
    {
        GameObject[] blueColliders = GameObject.FindGameObjectsWithTag("BlueCollider");
        foreach (GameObject blueCollider in blueColliders)
        {
            blueCollider.GetComponent<Collider>().enabled = false;
            blueCollider.GetComponent<MeshRenderer>().material = _blueGlassMaterial;
        }
    }

    IEnumerator ResetColorCountdown()
    {
        yield return new WaitForSeconds(_colorDuration);
        _player.GetComponent<MeshRenderer>().sharedMaterial = _whiteMaterial;
        
        DisableRedColliders();
        DisableBlueColliders();
    }
}
