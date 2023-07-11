using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioManager audioManager;
    public AudioClip sonidoSalto;
    public AudioClip sonidodash;
       CharacterController _controller;
    Transform _mainCameraTransform;
    [SerializeField] float _moveSpeed = 7.6f;
    float _turnSmoothVelocity;
    [SerializeField] float _turnSmoothFactor = 0.08f;
    [Space]
    [SerializeField] float _gravityForce  = -24.525f;  // -9.81 * 2.5
    [SerializeField] float _sphereGravityMultiplier = 1.4f;
    float _ySpeed;
    Vector3 _direction;
    [SerializeField] float _jumpForce = 9.0f;
    [SerializeField] float _sphereJumpMultiplier = 1.5f;
    [Space]
    [SerializeField] float _dashSpeed = 24f;
    [SerializeField] float _dashDuration = 0.14f;
    bool _canDash;
    [HideInInspector] public enum PlayerMesh { Cube, Sphere }
    [HideInInspector] public PlayerMesh playerMesh;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _mainCameraTransform = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {
        if (GameManager.Instance.IsPaused())
            return;
        
        Gravity();
        Jump();
        Movement();
        Dash();

        // --- debugggg ---
        //
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     if (playerMesh == PlayerMesh.Cube)
        //     {
        //         playerMesh = PlayerMesh.Sphere;
        //         gameObject.GetComponent<MeshFilter>().mesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
        //         Debug.Log("DEBUG: PlayerMesh -> Sphere");
        //     }

        //     else if (playerMesh == PlayerMesh.Sphere)
        //     {
        //         playerMesh = PlayerMesh.Cube;
        //         gameObject.GetComponent<MeshFilter>().mesh = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
        //         Debug.Log("DEBUG: PlayerMesh -> Cube");
        //     }
        // }
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 directionRaw = new Vector3(horizontal, 0, vertical).normalized;

        if (directionRaw.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(directionRaw.x, directionRaw.z) * Mathf.Rad2Deg + _mainCameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothFactor);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
            
            _direction = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _controller.Move(_direction.normalized * _moveSpeed * Time.deltaTime);
        
        }
    }

    void Gravity()
    {
        if (IsGrounded() && _ySpeed < 0.0f)
        {
            _ySpeed = -1.0f;
            _canDash = false;
        }
        else
        {
            if (playerMesh == PlayerMesh.Cube)
            {
                _ySpeed += _gravityForce * Time.deltaTime;
            }
            else
            {
                _ySpeed += _gravityForce * _sphereGravityMultiplier * Time.deltaTime;
            }
        }
        
        _direction = new Vector3(0, _ySpeed, 0);
        _controller.Move(_direction * Time.deltaTime);
    }

    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && IsGrounded())
        {
            NormalizeYSpeed();
            _canDash = true;

            if (playerMesh == PlayerMesh.Cube)
            {
                _ySpeed += _jumpForce;
            }
            else
            {
                _ySpeed += _jumpForce * _sphereJumpMultiplier;
            }
            audioManager.ReproducirSonido(sonidoSalto);
        }
    }

    void Dash()
    {
        if (playerMesh == PlayerMesh.Sphere)
            return;

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1)) && !IsGrounded() && _canDash)
        {
            StartCoroutine(DoDash());
            _canDash = false;
            audioManager.ReproducirSonido(sonidodash);
        }
        
    }

    IEnumerator DoDash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + _dashDuration)
        {
            _controller.Move(new Vector3(_direction.x, 0, _direction.z) * _dashSpeed * Time.deltaTime);
            _ySpeed = 0;

            yield return null;
        }
    }

    bool IsGrounded() => _controller.isGrounded;
    float NormalizeYSpeed() => _ySpeed = 0;
}
