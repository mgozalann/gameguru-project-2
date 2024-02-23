using System;
using UnityEngine;

public class StackSpawner : MonoBehaviour
{
    [SerializeField] private Stack[] _stacks;

    [SerializeField] private Vector3 _spawnPos;
    [SerializeField] private float _offSet;

    [SerializeField] private StackManager _stackManager;
    [SerializeField] private StackPlacer _stackPlacer;

    [SerializeField] private int _spawnCount; // bölümde kaç tane stack spawn edileceğini tutar.

    private bool _left;
    private int _counter;
    private int _stackCount;

    private void Start()
    {
        _stackPlacer.OnSpawnStack += OnSpawn;
    }

    private void OnSpawn()
    {
        
        if (_stackCount >= _spawnCount)
        {
            _stackManager.SetLastStack(_stackManager.FinisherStack);
            return;
        }
        
        Stack stack = Instantiate(_stacks[_counter]);
        
        _stackManager.SetCurrentStack(stack);
        
        _stackManager.CurrentStack.transform.position = _left
            ? new Vector3(-_spawnPos.x, _spawnPos.y, _spawnPos.z + _stackCount * _offSet)
            : new Vector3(_spawnPos.x, _spawnPos.y, _spawnPos.z + _stackCount * _offSet);
        
        _stackManager.CurrentStack.MoveRight = _left;
        _stackManager.CurrentStack.transform.localScale = _stackManager.LastStack.transform.localScale;
        
        _counter++;
        _stackCount++;
        
        if (_counter == _stacks.Length)
        {
            _counter = 0;
        }
        
        _left = !_left;
    }

    private void OnDisable()
    {
        _stackPlacer.OnSpawnStack -= OnSpawn;
    }
}