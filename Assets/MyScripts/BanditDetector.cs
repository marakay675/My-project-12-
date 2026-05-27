using UnityEngine;
using System;

public class BanditDetector : MonoBehaviour
{
    public event Action HasEntered;
    public event Action HasExited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BanditMover>(out BanditMover bandit))
            HasEntered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<BanditMover>(out BanditMover bandit))
            HasExited?.Invoke();
    }
}
