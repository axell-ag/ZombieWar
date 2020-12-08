using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPosition;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2f);
        _enemy.SetActive(true);
        //_enemy.transform.position = transform.position;
        Instantiate(_enemy, _spawnPosition.position, Quaternion.identity);
        Start();
    }
}
