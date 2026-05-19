using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _waypointParent;
    [SerializeField] private float _speedMultiplier = 5f;

    private int _index = 0;
    private Transform[] _wayPoints;

    private void Start()
    {
        _wayPoints = new Transform[_waypointParent.childCount];

        for (int i = 0; i < _waypointParent.childCount; i++)
        {
            _wayPoints[i] = _waypointParent.GetChild(i);
        }
    }

    private void Update()
    {
        var targetWaypoint = _wayPoints[_index];

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, _speedMultiplier * Time.deltaTime);

        if (transform.position == targetWaypoint.position) 
            SelectNextWaypoint();
    }

    private void SelectNextWaypoint()
    {
        _index++;

        if (_index == _wayPoints.Length)
            _index = 0;

        Vector3 targetDirection = _wayPoints[_index].position - transform.position;

        transform.forward = targetDirection.normalized;
    }
}
