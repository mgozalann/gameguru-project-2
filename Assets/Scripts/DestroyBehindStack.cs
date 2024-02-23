using System;
using UnityEngine;

public class DestroyBehindStack : MonoBehaviour
{
    [SerializeField] private StackObjectPool _stackObjectPool;
    [SerializeField] private StackManager _stackManager;

    private void Start()
    {
        _stackManager.onCurrentStackChanged+=OnCurrentChanged;
    }

    private void OnCurrentChanged(Stack arg1, Stack arg2)
    {
     //  _stackObjectPool.ReturnStackToPool(arg1);
    }

    private void OnDisable()
    {
        _stackManager.onCurrentStackChanged-=OnCurrentChanged;

    }
}