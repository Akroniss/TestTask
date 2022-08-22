using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _speedBullet = 10;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _period = 1;

    [SerializeField] private Bullet _bulletPrafab;
    [SerializeField] private byte _poolAmount = 10;
    private List<Bullet> _pool = new List<Bullet>();
    private void Start()
    {
        PoolFilling();
        StartCoroutine(Timer());
    }
    private void PoolFilling()
    {
        GameObject pool = new GameObject("PoolBullets");
        for (int i = 0; i < _poolAmount; i++)
        {
            _pool.Add(Instantiate(_bulletPrafab, pool.transform));
        }
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            Shot();
            yield return new WaitForSeconds(1 / _period);
        }
    }
    private void Shot()
    {
        Bullet bullet = _pool[0];
        bullet.Starting(transform.position, _speedBullet, _damage);
        _pool.Remove(bullet);
        _pool.Add(bullet);
    }
}
