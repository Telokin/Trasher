using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1,10)]
    private float _jumpForce;
    [Space(20)]
    [SerializeField]
    [Range(1,60)]
    private float _movementSpeed;


    private Transform _orientation;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _moveDirection;

    private Rigidbody _rigidbody;

    [SerializeField]
    private float _playerHeight;

    [SerializeField]
    private LayerMask _ground;

    private bool _grounded;

    [SerializeField]
    private float _groundDrag;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _orientation = GetComponent<Transform>();
        _rigidbody.freezeRotation = true;
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
        _rigidbody.AddForce(_moveDirection * _movementSpeed, ForceMode.Force);
        _grounded = Physics.Raycast(transform.position, Vector3.down, _playerHeight, _ground);
        _rigidbody.drag = _grounded ? _groundDrag : 0f;
        LimitSpeed();
    }

    private void LimitSpeed()
    {
        var velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
        if(velocity.magnitude > _movementSpeed)
        {
            var limitedVelosity = velocity.normalized * _movementSpeed;
            _rigidbody.velocity = new Vector3(limitedVelosity.x, _rigidbody.velocity.y, limitedVelosity.z);
        }
    }

    private void Jump()
    {
        if(_grounded == true)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);

            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }

    }
}
