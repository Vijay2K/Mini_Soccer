using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenGoal : MonoBehaviour
{
    public event Action OnGoldenGoalStart;
    public event Action OnGoldenGoalCompleted;

    private bool isGoldenGoal;

    private void Start() 
    {
        GameManager.Instance.OnGameDraw += StartGoldenGoal;
        GoalPost.OnGoal += GameOver;
    }

    private void StartGoldenGoal()
    {
        OnGoldenGoalStart?.Invoke();
        isGoldenGoal = true;
    }

    private void GameOver(PlayerType playerType)
    {
        if(isGoldenGoal)
        {
            isGoldenGoal = false;
            OnGoldenGoalCompleted?.Invoke();
        }
    }

    public bool IsGoldenGoal()
    {
        return isGoldenGoal;
    }
}
