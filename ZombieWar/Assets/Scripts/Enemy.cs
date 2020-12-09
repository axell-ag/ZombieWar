using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieWar;

public class Enemy : Singleton<Enemy>
{
    private Animator _animator;

    private float _speed = .7f;
    private float _health = 20f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        MovementCharacter();
        Flip();
    }
    private void MovementCharacter()
    {
        if (_health > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, Portal.Instance.transform.position, _speed * Time.deltaTime);
            _animator.SetInteger("State", 2);
        }
    }
    private void TakeDamage()
    {
        _health -= 7f;
        print(_health);
        if (_health <= 0 )
        {
            _animator.SetInteger("State", 3);
            StartCoroutine(DeathEnemy());
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
    private void Flip()
    {
        if (transform.position.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private IEnumerator DeathEnemy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
