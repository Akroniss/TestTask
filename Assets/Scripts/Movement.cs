using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    private void OnMouseDrag()
    {
        if (enabled)
        {
            transform.position = new Vector3(_camera.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z);
        }
    }
    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _speed;
    }
}
