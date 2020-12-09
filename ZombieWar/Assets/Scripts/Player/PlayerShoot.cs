using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _effect;
    public void ShootPlayer()
    {
        Instantiate(_bullet, _bulletPosition.position, _bulletPosition.rotation);
        _effect.SetActive(true);
        StartCoroutine(FireShoot());
    }
    private IEnumerator FireShoot()
    {
        yield return new WaitForSeconds(0.25f);
        _effect.SetActive(false);
    }
}
