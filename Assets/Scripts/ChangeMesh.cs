using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip sonidotransformacion;
    GameObject _player;

    void Start()
    {
        _player = GameManager.Instance.player;
    }

    void Update()
    {
        if (GameManager.Instance.IsPaused())
            return;
        
        transform.Rotate(0, 0.45f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        _player.GetComponent<MeshFilter>().mesh = gameObject.GetComponent<MeshFilter>().mesh;

        if (IsSpherePickup())
        {
            _player.GetComponent<PlayerMovement>().playerMesh = PlayerMovement.PlayerMesh.Sphere;
        }

        if (IsCubePickup())
        {
            _player.GetComponent<PlayerMovement>().playerMesh = PlayerMovement.PlayerMesh.Cube;
        }
        audioManager.ReproducirSonido(sonidotransformacion, 0.48f);
    }

    bool IsSpherePickup() => gameObject.GetComponent<MeshFilter>().mesh.name == "Sphere Instance";
    bool IsCubePickup() => gameObject.GetComponent<MeshFilter>().mesh.name == "Cube Instance";
}
