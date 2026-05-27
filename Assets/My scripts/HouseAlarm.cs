using System.Collections;
using UnityEngine;

public class HouseAlarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private BanditDetector detector;
    [SerializeField] float _speed = 0.3f;

    Coroutine _fadeCoroutine;

    private void OnBanditEntered()
    {
        float targetVolume = 1f;

        if (_alarm.isPlaying == false)
            _alarm.Play();

        StartFade(targetVolume);
    }

    private void OnBanditExited()
    {
        float targetVolume = 0f;

        StartFade(targetVolume);
    }

    private IEnumerator FadeRoutine(float targetVolume)
    {
        float minVolume = 0f;

        while (_alarm.volume != targetVolume)
        {
        _alarm.volume = Mathf.MoveTowards(_alarm.volume, targetVolume, _speed * Time.deltaTime);
        yield return null;
        }

        if (targetVolume == minVolume)
            _alarm.Stop();
    }

    private void StartFade(float targetVolume)
    {
        if (_fadeCoroutine != null)
            StopCoroutine(_fadeCoroutine);

        _fadeCoroutine = StartCoroutine(FadeRoutine(targetVolume));
    }

    private void OnEnable()
    {
        detector.HasEntered += OnBanditEntered;
        detector.HasExited += OnBanditExited;
    }

    private void OnDisable()
    {
        detector.HasEntered -= OnBanditEntered;
        detector.HasExited -= OnBanditExited;
    }
}
