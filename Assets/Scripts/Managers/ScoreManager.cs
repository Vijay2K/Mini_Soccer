using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public event Action<int, int> OnScoreChanged;

    private int player_1_score;
    private int player_2_score;

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

        Debug.Log("Player - 1 : " + player_1_score + " and " + "Player - 2 : " + player_2_score);
        OnScoreChanged?.Invoke(player_1_score, player_2_score);
    }
}
