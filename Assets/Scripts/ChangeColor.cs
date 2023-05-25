using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Material _redMaterial;
    [SerializeField] Material _redGlassMaterial;
    [SerializeField] Material _blueMaterial;
    [SerializeField] Material _blueGlassMaterial;

    void Update()
    {
        transform.Rotate(0, 0.35f, 0, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        Material pickupColor = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
        _player.GetComponent<MeshRenderer>().sharedMaterial = pickupColor;

        if (_player.GetComponent<MeshRenderer>().sharedMaterial == _redMaterial)
        {
            EnableRedColliders();

            // test
            _player.GetComponent<MeshFilter>().mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
        }

        if (_player.GetComponent<MeshRenderer>().sharedMaterial == _blueMaterial)
        {
            EnableBlueColliders();
        }
    }

    void EnableRedColliders()
    {
        GameObject[] redColliders = GameObject.FindGameObjectsWithTag("RedCollider");
        foreach (GameObject redCollider in redColliders)
        {
            redCollider.GetComponent<Collider>().enabled = true;
            redCollider.GetComponent<MeshRenderer>().material = _redMaterial;
        }

        GameObject[] blueColliders = GameObject.FindGameObjectsWithTag("BlueCollider");
        foreach (GameObject blueCollider in blueColliders)
        {
            blueCollider.GetComponent<Collider>().enabled = false;
            blueCollider.GetComponent<MeshRenderer>().material = _blueGlassMaterial;
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

        GameObject[] redColliders = GameObject.FindGameObjectsWithTag("RedCollider");
        foreach (GameObject redCollider in redColliders)
        {
            redCollider.GetComponent<Collider>().enabled = false;
            redCollider.GetComponent<MeshRenderer>().material = _redGlassMaterial;
        }
    }
}
