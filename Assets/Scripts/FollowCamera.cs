using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float _offsetY = 4;
    private float _x;
    private float _z;
    void Start()
    {
        _player = GameObject.Find("Player");
        _x = transform.position.x;
        _z = transform.position.z;
        _offsetY = transform.position.y - _player.transform.position.y;
    }
    void Update()
    {
        transform.position = new Vector3(_x, _player.transform.position.y + _offsetY, _z);
    }
}
