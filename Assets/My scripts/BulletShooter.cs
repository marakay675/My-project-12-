using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]

public class BulletShooter : MonoBehaviour
{
    [FormerlySerializedAs("number")]
    [SerializeField] private float _bulletSpeed;

    [FormerlySerializedAs("_timeWaitShooting")]
    [SerializeField] private float _delayTime;

    [SerializeField] private Rigidbody _prefab;

    [FormerlySerializedAs("ObjectToShoot")]
    [SerializeField] private Transform _objectToShoot;

    private void Start() 
    {
           StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWorking = true;

        while (isWorking = true)
        {
            var direction = (_objectToShoot.position - transform.position).normalized;
             Rigidbody newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

                newBullet.transform.up = direction;
                newBullet.velocity = direction * _bulletSpeed;

              yield return new WaitForSeconds(_delayTime);
         }
    }
}