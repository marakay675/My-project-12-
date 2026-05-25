using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] float _speed = 0.3f;

    private bool _banditHasEntered = false;

    private void Update()
    {
        if (_banditHasEntered == true)
        {
            float targetVolume = 1f;

            _alarm.volume = Mathf.MoveTowards(_alarm.volume, targetVolume, _speed * Time.deltaTime);
        }

        if (_banditHasEntered == false)
        {
            float targetVolume = 0f;
            _alarm.volume = Mathf.MoveTowards(_alarm.volume, targetVolume, _speed * Time.deltaTime);

            if (_alarm.volume == targetVolume)
                _alarm.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bandit")
        {
            _alarm.Play();
            _banditHasEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bandit")
            _banditHasEntered = false;
    }
}
