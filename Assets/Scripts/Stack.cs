using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Stack : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private MeshRenderer _meshRenderer;
    public MeshRenderer MeshRenderer => _meshRenderer;
    
    [SerializeField] private GameObject _dropStack;
    public GameObject DropStack => _dropStack;

    private float _distance;
    private float _length;
    
    private bool _moveForward;
    private bool _canMove;
    
    public bool MoveRight;
    
    private void Start()
    {
        _canMove = true;
        
        _maxDistance = 5f;
        _distance = _maxDistance;
        _moveForward = true;
    }

    private void Update()
    {
        if (!_canMove) return;

        _length = Time.deltaTime * _moveSpeed;
        Move();
    }

    public void Stop()
    {
        _canMove = false;
    }

    private void Move()
    {
        int multiplier = MoveRight? -1 : 1;
        
        if(_moveForward)
        {
            if (_distance < _maxDistance)
            {
                transform.Translate(multiplier * _length,0,0);
                _distance += _length;
            }
            else
            {
                _moveForward = false;
            }
        }
        else
        {
            if (_distance > -_maxDistance)
            {
                transform.Translate(multiplier * -_length,0,0);
                _distance -= _length;
            }
            else
            {
                _moveForward = true;
            }
        }
    }
}
