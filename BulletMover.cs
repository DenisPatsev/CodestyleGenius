using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWorking = enabled;
        var wait = new WaitForSeconds(_delay);

        while (isWorking)
        {
            var distanceToTarget = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + distanceToTarget, Quaternion.identity);

            newBullet.transform.up = distanceToTarget;
            newBullet.velocity = distanceToTarget * _speed;

            yield return wait;
        }
    }
}