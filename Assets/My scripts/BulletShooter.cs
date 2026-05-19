using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletShooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _delayTime;
    [SerializeField]private GameObject _prefab;
    [SerializeField] private Transform ObjectToShoot;

    private void Start() 
    {
           StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        bool isWorking = true;

        while (isWorking = true)
        {
            var direction = (ObjectToShoot.position - transform.position).normalized;
             var newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

                newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _bulletSpeed;

              yield return new WaitForSeconds(_delayTime);
         }
    }
}