using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieWar;

public class Enemy : Singleton<Enemy>, IMove
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private float _speed = .7f;
    private float _health = 20f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        MovementCharacter();
    }
    public void MovementCharacter()
    {
        transform.position = Vector2.MoveTowards(transform.position, Portal.Instance.transform.position, _speed * Time.deltaTime);
    }
    private void TakeDamage()
    {
        _health = _health - 7f;
        print(_health);
        if (_health <= 0 )
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            TakeDamage();
        }
        if (collision.gameObject.name == "Portal")
        {
            Destroy(gameObject);
        }
    }
}
