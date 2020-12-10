using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _text;

    private float _speed = 3f;
    private Transform _target;

    private void Start()
    {
        StartCoroutine(Title());
        _target = PlayerMove.Instance.transform;
        transform.position = new Vector3(_target.transform.position.x, _target.transform.position.y, transform.position.z);
    }
    private void Update()
    {
        Vector3 position = _target.position;
        position.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime); ;
    }
    private IEnumerator Title()
    {
        _text.SetActive(true);
        yield return new WaitForSeconds(1f);
        _text.SetActive(false);
    }
}
