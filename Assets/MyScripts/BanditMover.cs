//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UIElements;

//public class BanditMover : MonoBehaviour
//{
//    [SerializeField] private float _speed = 3;
//    [SerializeField] private Transform[] _wayPoints;

//    private int _currentIndex = 0;

//    private void Update()
//    {
//        Transform targetPoint = _wayPoints[_currentIndex];

//        Vector3 direction = (targetPoint.position - transform.position).normalized;

//        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
//        transform.LookAt(targetPoint);

//        float distance = Vector3.Distance(transform.position, targetPoint.position);

//        if (distance < 0.2f)
//        {
//            _currentIndex++;

//            if (_currentIndex >= _wayPoints.Length)
//            {
//                _currentIndex = 0;
//            }
//        }
//    }
//}
