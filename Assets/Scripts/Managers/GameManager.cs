using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<PlayerType> OnGameOver;

    private PlayerType winner;

    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        FindObjectOfType<GameCountdown>().OnCountdownStopped += GameOver;
    }

    private void GameOver()
    {
        ChooseTheWinner();
        OnGameOver?.Invoke(winner);
    }

    private void ChooseTheWinner()
    {
        if (ScoreManager.Instance.GetPlayer_1_Score() > ScoreManager.Instance.GetPlayer_2_Score())
        {
            winner = PlayerType.Player_1;
        }
        else if (ScoreManager.Instance.GetPlayer_1_Score() < ScoreManager.Instance.GetPlayer_2_Score())
        {
            winner = PlayerType.Player_2;
        }
        else if (ScoreManager.Instance.GetPlayer_1_Score() == ScoreManager.Instance.GetPlayer_2_Score())
        {
            winner = PlayerType.NONE;
        }
    }
}
