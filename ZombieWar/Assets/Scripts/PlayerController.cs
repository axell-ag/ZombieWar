using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieWar;

public class PlayerController : Singleton<PlayerController>
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _effect; 

    private float _speed;
    private float _jumpHeight = 7f;
    private bool _isGrounded;

    public void JumpPlayer()
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
        MovementPlayer();
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }
    private void MovementPlayer()
    {
        if(_joystick.Horizontal != 0)
        {
            Move(5f, 3);
        }
        if(_joystick.Horizontal == 0)
        {
            Move(0f, 1);
        }
        void Move (float speed, int animation)
        {
            _speed = speed * _joystick.Horizontal;
            _animator.SetInteger("State", animation);
        }
    }
    private void Flip()
    {
        //Quaternion flip = _joystick.Horizontal < 0 ? transform.localRotation = Quaternion.Euler(0, 180, 0) : transform.localRotation = Quaternion.Euler(0, 0, 0);
        if(_joystick.Horizontal < 0)
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
    public void ShootPlayer()
    {
        Instantiate(_bullet, _bulletPosition.position, _bulletPosition.rotation);
        _effect.SetActive(true);
        StartCoroutine(FireShoot());
    }
    private IEnumerator FireShoot()
    {
        yield return new WaitForSeconds(0.21f);
        _effect.SetActive(false);
    }
}
