using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZombieWar;

public class Portal : Singleton<Portal>
{
    [SerializeField] private Text _text;
    private int _runAway;

    private void Start()
    {
        _runAway = 0;
    }
    private void Update()
    {
        _text.text = _runAway.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _runAway++;
        }
    }
}
