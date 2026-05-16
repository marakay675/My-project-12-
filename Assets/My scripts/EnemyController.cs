using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 4f;
    private Transform _target;

    public void InitializeTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        Vector3 direction = (_target.position - transform.position).normalized;

        transform.LookAt(_target);

        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
    }
}
