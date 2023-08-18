using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeBetweenShots;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _target;

    void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWorking = enabled;
        var wait = new WaitForSeconds(_timeBetweenShots);

        while (isWorking)
        {
            var distanceToTarget = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + distanceToTarget, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = distanceToTarget;
            newBullet.GetComponent<Rigidbody>().velocity = distanceToTarget * _speed;

            yield return wait;
        }
    }
}