using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    CharacterController _controller;
    [SerializeField] Transform _target;
    void Awake()
    {
        // _controller = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    void Start()
    {
        _controller = GameManager.Instance.player.GetComponent<CharacterController>();
    }
    void OnTriggerEnter(Collider other)
    {
        _controller.enabled = false;
        _controller.transform.position = _target.position;
        _controller.enabled = true;
    }
}
