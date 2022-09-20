using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPost : MonoBehaviour
{
    public static event Action<PlayerType> OnGoal;

    [SerializeField] private PlayerType whosGoalPost;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ball"))
        {
            OnGoal?.Invoke(whosGoalPost);
        }    
    }
}
