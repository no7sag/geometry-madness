using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] float _moveSpeed = 7.5f;
    [SerializeField] Transform mainCameraTransform;
    float _gravity = -9.81f;
    [SerializeField] float _gravityMultiplier = 2.0f;
    float _ySpeed;
    Vector3 _direction;
    [SerializeField] float _jumpForce = 9.0f;
    public static bool freezeMovement;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        float correctHeight = controller.center.y + controller.skinWidth;
        controller.center = new Vector3(0, correctHeight, 0);
    }

    void Update()
    {
        // if (GameManager.Instance.IsPaused())
            // return;
        
        Gravity();
        Jump();
        Movement();
    }

    void Movement()
    {
        if (freezeMovement)
            return;
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 directionRaw = new Vector3(horizontal, 0, vertical).normalized;

        if (directionRaw.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(directionRaw.x, directionRaw.z) * Mathf.Rad2Deg + mainCameraTransform.eulerAngles.y;
            
            _direction = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(_direction.normalized * _moveSpeed * Time.deltaTime);
        }
    }

    void Gravity()
    {
        if (IsGrounded() && _ySpeed < 0.0f)
        {
            _ySpeed = -1.0f;
        }
        else
        {
            _ySpeed += _gravity * _gravityMultiplier * Time.deltaTime;
        }
        
        _direction = new Vector3(0, _ySpeed, 0);
        controller.Move(_direction * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded())
            {
                NormalizeYSpeed();
                _ySpeed += _jumpForce;
            }
        }
    }

    private bool IsGrounded() => controller.isGrounded;
    private float NormalizeYSpeed() => _ySpeed = 0;
}
