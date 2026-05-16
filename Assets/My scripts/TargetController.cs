using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 6;
    [SerializeField] private Transform[] _wayPoints;

    private int _currentPointIndex = 0;

    private void Update()
    {
        Transform targetPoint = _wayPoints[_currentPointIndex];

        Vector3 direction = (targetPoint.position - transform.position).normalized;
        transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
        transform.LookAt(targetPoint);

        float distance = Vector3.Distance(transform.position, targetPoint.position);

        if (distance < 0.2f)
        {
            _currentPointIndex++;

            if (_currentPointIndex >= _wayPoints.Length)
            {
                _currentPointIndex = 0;
            }
        }
    }
}
