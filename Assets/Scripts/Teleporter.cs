using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform target;

    void OnTriggerEnter(Collider other)
    {
        controller.enabled = false;
        controller.transform.position = target.position;
        controller.enabled = true;
    }
}
