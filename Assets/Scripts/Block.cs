using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] private int _power;
    private Text _text;
    private void Start()
    {
        _text = GetComponentInChildren<Text>();
        _text.text = _power.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            bullet.gameObject.SetActive(false);
            _power -= bullet.Damage;
            _text.text = _power.ToString();
            if (_power <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
