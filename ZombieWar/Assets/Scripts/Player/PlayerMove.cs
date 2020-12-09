using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieWar;

public class PlayerMove : Singleton<PlayerMove>
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;

    private float _speed;
    private float _jumpHeight = 7f;
    private bool _isGrounded;

    public void OnJumpButtonDown()
    {
        JumpPlayer();
    }
    private void JumpPlayer()
    {
        if (_isGrounded)
        {
            _rigidbody.velocity = Vector2.up * _jumpHeight;
        }
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Flip();
        GroundCheck();
    }
    private void FixedUpdate()
    {
        MovementCharacter();
        //_rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }
    private void MovementCharacter()
    {
        if (_joystick.Horizontal != 0)
        {
            Move(5f, 3);
        }
        if (_joystick.Horizontal == 0)
        {
            Move(0f, 1);
        }
        void Move(float speed, int animation)
        {
            _speed = speed * _joystick.Horizontal;
            _animator.SetInteger("State", animation);
            _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
        }
    }
    private void Flip()
    {
        if (_joystick.Horizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (_joystick.Horizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, 0.2f, _whatIsGround);
        _isGrounded = colliders.Length > 1;
    }
}
