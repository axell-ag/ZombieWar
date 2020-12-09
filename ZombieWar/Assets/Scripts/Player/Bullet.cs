using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieWar;

public class Bullet : Singleton<Bullet>
{
    private float _speed = 10f;
    private float _liveTime = 1f;
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
        _liveTime = _liveTime - Time.deltaTime;
        if (_liveTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Enemy.Instance != null)
        {
            Destroy(gameObject);
        }
    }
}
