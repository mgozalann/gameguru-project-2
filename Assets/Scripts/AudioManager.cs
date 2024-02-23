using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private int _currentClipIndex = 0;

    private void Start()
    {
        GameEvents.Instance.OnStackPerfect += PlayerPerfectSound;
    }

    private void PlayerPerfectSound(bool tr)
    {

        if (tr)
        {
            _audioSource.pitch = 1 + _currentClipIndex * 0.025f; 
            _audioSource.Play();
            _currentClipIndex++;
        }
        else
        {
            _currentClipIndex = 0;
        }

    }

    private void OnDisable()
    {
        GameEvents.Instance.OnStackPerfect -= PlayerPerfectSound;
    }
}