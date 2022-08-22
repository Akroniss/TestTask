using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage { get; private set; }
    [SerializeField] private float _distance = 20;
    public void Starting(Vector3 startPosition, float speed, int damage)
    {
        Damage = damage;
        gameObject.SetActive(true);
        transform.position = startPosition;
        StartCoroutine(Flight(startPosition.y + _distance, speed));
    }
    private IEnumerator Flight(float endPosition, float speed)
    {
        while (transform.position.y < endPosition)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        gameObject.SetActive(false);
    }
}
