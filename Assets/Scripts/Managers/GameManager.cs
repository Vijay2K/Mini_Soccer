using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<PlayerType> OnGameOver;
    public event Action OnGameDraw;

    private PlayerType winner;
    private bool isGameOver;

    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        FindObjectOfType<GameCountdown>().OnCountdownStopped += GameOver;
        FindObjectOfType<GoldenGoal>().OnGoldenGoalCompleted += GameOver;
    }

    private void GameOver()
    {
        StartCoroutine(GameoverDelay());
    }

    private IEnumerator GameoverDelay()
    {
        yield return new WaitForSeconds(0.5f);
        if(IfAnyPlayerWon())
        {
            isGameOver = true;
            OnGameOver?.Invoke(winner);
        }
        else
        {
            OnGameDraw?.Invoke();
        }
    }

    private bool IfAnyPlayerWon()
    {
        if (ScoreManager.Instance.GetPlayer_1_Score() > ScoreManager.Instance.GetPlayer_2_Score())
        {
            winner = PlayerType.Player_1;
            return true;
        }
        else if (ScoreManager.Instance.GetPlayer_1_Score() < ScoreManager.Instance.GetPlayer_2_Score())
        {
            winner = PlayerType.Player_2;
            return true;
        }
        else if (ScoreManager.Instance.GetPlayer_1_Score() == ScoreManager.Instance.GetPlayer_2_Score())
        {
            Debug.Log("Match Draw");
            return false;
        }

        return false;
    }

    public bool IsGameover()
    {
        return isGameOver;
    }
}
