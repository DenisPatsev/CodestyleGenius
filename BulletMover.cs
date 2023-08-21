using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWorking = enabled;
        var wait = new WaitForSeconds(_timeBetweenShots);
        Rigidbody bulletRigidbody;

        while (isWorking)
        {
            var distanceToTarget = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + distanceToTarget, Quaternion.identity);

            bulletRigidbody = newBullet.GetComponent<Rigidbody>(); 

            bulletRigidbody.transform.up = distanceToTarget;
            bulletRigidbody.velocity = distanceToTarget * _speed;

            yield return wait;
        }
    }
}