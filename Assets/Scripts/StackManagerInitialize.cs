using UnityEngine;

public class StackManagerInitialize : MonoBehaviour
{
    [SerializeField] private Stack _starterStack;
    [SerializeField] private Stack _finisherStack;

    [SerializeField] private StackManager _stackManager;
    private void Awake()
    {
        _stackManager.SetStarterStack(_starterStack);
        _stackManager.SetFinisherStack(_finisherStack);
        _stackManager.SetLastStack(_starterStack);
    }
}
