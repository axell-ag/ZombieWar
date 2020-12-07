using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed = 10f;
    private float _liveTime = 2f;
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
        
    }
}
