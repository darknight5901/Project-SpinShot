using System;
using UnityEngine;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public static GameManager _ { get; private set; }

    public int currentRound = 1;
    public int maxRounds = 6;

    public enum GameState { WaitingToStart, RoundStarted, RoundInProgress, RoundEnd, ShopStart, ShopEnd, GameOver }
    public GameState currentGameState = GameState.WaitingToStart;
    public static event Action<GameManager> OnStartNewRound; // new


    private void Awake()
    {
        if(_ == null)
        {
            _ = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartNewRound();
    }
    public void StartNewRound()
    {
        if (currentRound <= maxRounds)
        {
            currentGameState = GameState.RoundStarted;
            Debug.Log($"Starting round {currentRound}");
        }
        else
        {
            EndGame();
        }

    }
    public void EndRound()
    {
        currentGameState = GameState.RoundEnd;
        Debug.Log($"Round {currentRound} has been Ended");
        currentRound++;
        Invoke(nameof(StartNewRound), 5f);
    }
    public void EndGame()
    {
        currentGameState = GameState.GameOver;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
