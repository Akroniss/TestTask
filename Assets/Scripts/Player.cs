using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<Player> Play;
    public static event Action<Player> GameOver;
    private Movement _movement;
    private Attack _attack;
    private void Start()
    {
        _movement = GetComponent<Movement>();
        _attack = GetComponent<Attack>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _movement.enabled = false;
        _attack.enabled = false;
        GameOver.Invoke(this);
    }
    private void OnMouseDown()
    {
        if (Play != null)
        {
            _movement.enabled = true;
            _attack.enabled = true;
            Play.Invoke(this);
        }
    }
}
