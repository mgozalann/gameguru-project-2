using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public event Action OnGameLose;
    public event Action OnGameWin;
    
    public bool GameEnded = false;

    public static GameManager Instance;

    public enum GameState
    {
        Started,
        Win,
        Lose
    }
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
    public void GameWin()
    {
        OnGameWin?.Invoke();
    }
}