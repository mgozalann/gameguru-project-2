using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private StackPlacer _stackPlayer;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    private int _currentClipIndex = 0;

    private void Start()
    {
        _stackPlayer.OnStackPerfect += PlayerPerfectSound;
    }

    private void PlayerPerfectSound(bool tr)
    {
        if (tr)
        {
            // _audioSource.clip = _audioClips[_currentClipIndex];
            // _audioSource.Play();
            _currentClipIndex++;
            if (_currentClipIndex == _audioClips.Length)
            {
                _currentClipIndex = 0;
            }
        }
        else
        {
            _currentClipIndex = 0;
        }
        Debug.Log(_currentClipIndex);

    }

    private void OnDisable()
    {
        _stackPlayer.OnStackPerfect -= PlayerPerfectSound;
    }
}