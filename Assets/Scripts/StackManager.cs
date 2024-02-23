using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StackManager", menuName = "ScriptableObjects/StackManager", order = 1)]
public class StackManager : ScriptableObject
{
    public Stack StarterStack;
    public Stack FinisherStack;
    
    private Stack _lastStack;
    public event Action<Stack, Stack> onLastStackChanged;
    public Stack LastStack
    {
        get => _lastStack;
        set
        {
            Stack oldValue = _lastStack;
            bool isChanged = _lastStack != value;
            _lastStack = value;
            if (isChanged)
            {
                onLastStackChanged?.Invoke(oldValue, value);
            }
        }
    }
    
    private Stack _currentStack;
    public event Action<Stack, Stack> onCurrentStackChanged;
    public Stack CurrentStack
    {
        get => _currentStack;
        set
        {
            Stack oldValue = _currentStack;
            bool isChanged = _currentStack != value;
            _currentStack = value;
            if (isChanged)
            {
                onCurrentStackChanged?.Invoke(oldValue, value);
            }
        }
    }
    
    public void SetLastStack(Stack stack)
    {
        LastStack = stack;
    }

    public void SetCurrentStack(Stack stack)
    {
        CurrentStack = stack;
    }

    public void SetStarterStack(Stack stack)
    {
        StarterStack = stack;
    }
    public void SetFinisherStack(Stack stack)
    {
        FinisherStack = stack;
    }
}