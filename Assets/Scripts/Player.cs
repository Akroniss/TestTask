using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static event Action<Player> Play;
    public static event Action<Player> GameOver;
    private void OnTriggerEnter(Collider other)
    {
        GameOver.Invoke(this);
    }
    private void OnMouseDown()
    {
        if (Play != null)
        {
            Play.Invoke(this);
        }
    }
}
