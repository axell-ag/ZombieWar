using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _effect;
    [SerializeField] private GameObject _refresh;
    [SerializeField] private Text _clipText;

    private Animator _animator;

    private int _clip = 100;
    public void ShootPlayer()
    {
        _animator.SetInteger("State", 5);
        _clip--;
        if (_clip >= 0)
        {
            Instantiate(_bullet, _bulletPosition.position, _bulletPosition.rotation);
            _effect.SetActive(true);
            StartCoroutine(FireShoot());
        }
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _clipText.text = _clip.ToString();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Clip(Clone)")
        {
            Destroy(collision.gameObject);
            StartCoroutine(Refresh());
            _clip += SpawnClip.Instance._bullet;
        }
    }
    private IEnumerator FireShoot()
    {
        yield return new WaitForSeconds(0.25f);
        _effect.SetActive(false);
    }
    private IEnumerator Refresh()
    {
        _refresh.SetActive(true);
        yield return new WaitForSeconds(.4f);
        _refresh.SetActive(false);
    }
}
