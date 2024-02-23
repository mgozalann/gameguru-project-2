using System.Collections.Generic;
using UnityEngine;

public class StackObjectPool : MonoBehaviour
{
    public Stack[] StackPrefabs;

    private Queue<Stack> _stackPool = new Queue<Stack>(); // Stacklerin havuzu

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < StackPrefabs.Length; i++)
        {
            Stack stackInstance = Instantiate(StackPrefabs[i]);
            stackInstance.gameObject.SetActive(false);
            _stackPool.Enqueue(stackInstance);
        }
    }

    public Stack GetStackFromPool()
    {
        if (_stackPool.Count > 0)
        {
            Stack stackInstance = _stackPool.Dequeue();
            stackInstance.gameObject.SetActive(true);
            return stackInstance;
        }

        return null;
    }

    public void ReturnStackToPool(Stack stackInstance)
    {
        stackInstance.gameObject.SetActive(false);
        _stackPool.Enqueue(stackInstance);
    }
}