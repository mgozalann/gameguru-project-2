using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

    private void Start()
    {
        GameManager.Instance.OnGameWin+=GameWin;
    }

    private void GameWin()
    {
        Vector3 transformPosition = _cinemachineVirtualCamera.Follow.transform.position;
        transformPosition.x = 0;
        
        _cinemachineVirtualCamera.Follow.transform.position = transformPosition;
        _cinemachineVirtualCamera.Follow.transform.rotation =Quaternion.identity;

        StartCoroutine(OrbitPlayer());
    }

    private IEnumerator OrbitPlayer()
    {
        while (true)
        {
            _cinemachineVirtualCamera.Follow.transform.Rotate(0, _turnSpeed * Time.deltaTime, 0);
            yield return null;
        }
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameWin-=GameWin;
    }
}
