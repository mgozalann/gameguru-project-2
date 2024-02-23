using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action OnSpawnStack;
    public event Action<bool> OnStackPerfect;
    
    public static GameEvents Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnStack()
    {
        OnSpawnStack?.Invoke();
    }
    
    public void StackPerfect(bool tr)
    {
        OnStackPerfect?.Invoke(tr);
    }
   
}