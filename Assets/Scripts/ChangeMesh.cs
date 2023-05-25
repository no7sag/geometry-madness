using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour
{
    [SerializeField] GameObject _player;

    void Update()
    {
        transform.Rotate(0, 0.35f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        _player.GetComponent<MeshFilter>().mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
    }
}
