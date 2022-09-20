using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public event Action<int, int> OnScoreChanged;

    private int player_1_score;
    private int player_2_score;

    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        GoalPost.OnGoal += CalculateScore;
    }

    private void CalculateScore(PlayerType playerType)
    {
        switch(playerType)
        {
            case PlayerType.Player_1:
                player_2_score++;
                break;
            case PlayerType.Player_2:
                player_1_score++;
                break;
        }

        OnScoreChanged?.Invoke(player_1_score, player_2_score);
    }

    public int GetPlayer_1_Score()
    {
        return player_1_score;
    }

    public int GetPlayer_2_Score()
    {
        return player_2_score;
    }
}
