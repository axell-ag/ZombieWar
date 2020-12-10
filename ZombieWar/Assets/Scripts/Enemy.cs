using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZombieWar;

public class Enemy : Singleton<Enemy>
{
    private Animator _animator;
    private SpriteRenderer _color;

    private float _speed = .7f;
    private float _health = 20f;
    private float _damage;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _color = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        MovementCharacter();
        Flip();
        _damage = Random.Range(4f, 7f);
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
        StartCoroutine(ChangeColor());
        _health -= _damage;
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
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
    private IEnumerator ChangeColor()
    {
        _color.material.color = new Color(1f, _color.color.g - 0.4f, _color.color.b - 0.4f);
        yield return new WaitForSeconds(.1f);
        _color.material.color = new Color(1f, _color.color.g + 0.1f, _color.color.b + 0.1f);
    }
}
