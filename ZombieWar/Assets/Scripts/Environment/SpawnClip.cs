using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieWar;

public class SpawnClip : Singleton<SpawnClip>
{
    [SerializeField] private Transform _clipPosition;
    [SerializeField] private GameObject _clip;

    private int _waitTime;
    public int _bullet;
    private void Start()
    {
        _bullet = Random.Range(15, 25);
        _waitTime = Random.Range(15, 25);
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_waitTime);
        Instantiate(_clip, _clipPosition.position, _clipPosition.rotation);
        Start();
    }
}
