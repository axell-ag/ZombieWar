using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnLeft;
    [SerializeField] private Transform _spawnRight;

    private float _spawnTime;
    private float _spawnPosition;
    private void Start()
    {
        _spawnTime = Random.Range(1f, 4f);
        _spawnPosition = Random.Range(0f, .2f);
        if (_spawnPosition < .1f)
        {
            StartCoroutine(SpawnEnemy(_spawnLeft));
        }
        if (_spawnPosition > .1f)
        {
            StartCoroutine(SpawnEnemy(_spawnRight));
        }
    }
    private IEnumerator SpawnEnemy(Transform spawn)
    {
        yield return new WaitForSeconds(_spawnTime);
        Instantiate(_enemy, spawn.position, Quaternion.Euler(0, 0, 0));
        Start();
    }
}
