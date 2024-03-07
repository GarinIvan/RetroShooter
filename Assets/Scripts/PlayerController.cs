using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0f;
    public float gravity = 9.8f;
    public float jumpForce = 2f;
    public float speed = 5f;
    private Vector3 _moveVector;
    private CharacterController _character;
    public Animator animator;
    void Start()
    {
        _character = GetComponent<CharacterController>();
    }
    void Update()
    {
        MovementUpdate();
        JumpUpdate();
    }
    void FixedUpdate()
    {
        _character.Move(_moveVector * speed * Time.fixedDeltaTime);
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _character.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
        if (_character.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
    void MovementUpdate()
    {
        var runDirection = 0;
        _moveVector = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDirection = 2;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDirection = 4;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 3;
        }
        animator.SetInteger("RunDirection", runDirection);
    }
    void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _character.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
}
