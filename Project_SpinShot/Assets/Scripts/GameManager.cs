using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Android;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _ { get; private set; }

    public int currentRound = 1;
    public int maxRounds = 6;
    public int playerCount;
    public float roundStartTimer = 3;
    [SerializeField] Coroutine timerCoroutine;
    public enum GameState { WaitingToStart, RoundStarted, RoundInProgress, RoundEnd, ShopStart,ShopInProgress, ShopEnd, GameOver }
    public GameState currentGameState = GameState.WaitingToStart;
    public UnityEvent<GameState> RoundChangeTriggered;


    [Header("Ui Elements")]
    public TMP_Text countdownTxt;

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
    public Action ProgressRound(GameState gamestate)
    {
        switch (gamestate)
        {
            case GameState.WaitingToStart:
                currentGameState = gamestate;

                break;
            case GameState.ShopStart:
                StartShopRound();

                break;
            case GameState.ShopInProgress:
                currentGameState = gamestate;
                break;
            case GameState.ShopEnd:
                EndShopRound();
                break;
            case GameState.RoundStarted:
                StartNewRound();

                break;
            case GameState.RoundInProgress:
                currentGameState = gamestate;
                break;
            case GameState.RoundEnd:
                EndRound();
                break;
            default:
                break;
               
            
              
        }
        print($"{currentRound} | {currentGameState} | {playerCount}"); 
                return null; 
    }
    public void StartNewRound()
    {
        if (currentRound <= maxRounds)
        {
            currentGameState = GameState.RoundStarted;
            Debug.Log($"Starting round {currentRound}");
            if (timerCoroutine != null)
            {
                timerCoroutine = null;
               // StartCoroutine(TimerCoroutine());
            }
            else
            {
                timerCoroutine = StartCoroutine(TimerCoroutineWithCallback(roundStartTimer() => {
                    Debug.Log("Timer was ended and new thing should be started");
                }));

            }
        }
        else
        {
            EndGame();
        }

    }
    IEnumerator TimerCoroutineWithCallback(Action onComplete, float countdownDuration, TMP_Text countdownText )
    {
        
        float currentTime = countdownDuration;
        while (currentTime > 0)
        {
            if (countdownText != null)
            {
                countdownText.text = currentTime.ToString("F1");
            }
            currentTime -= Time.deltaTime;
            yield return null;
        }
        if (countdownText != null)
        {
            countdownText.text = "Go!!!";
            timerCoroutine = null;
            onComplete?.Invoke();
        }

    }
    public void EndRound()
    {
        // prepare for the next round and start it
        currentGameState = GameState.RoundEnd;
        Debug.Log($"Round {currentRound} has been Ended");
        currentRound++;
        // old Invoke(nameof(StartNewRound), 5f);
        ProgressRound(GameState.RoundStarted);
    }
    public void StartShopRound()
    {
        //initiate any shop loading logic here then progress.
        ProgressRound(GameState.ShopInProgress);
    }
    public void EndShopRound()
    {
        //finalize and save any shop changes and end the round
        ProgressRound(GameState.RoundEnd);
    }
    public void EndGame()
    {
        //game is fully over
        currentGameState = GameState.GameOver;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnRoundChange()
    {
        RoundChangeTriggered.Invoke(currentGameState);
    }
}
