using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "Create Player Data/New Player Data")]
public class PlayerDataSO : ScriptableObject
{
    [SerializeField] private PlayerType playerType;
    [SerializeField] private float moverSpeed;
    [SerializeField] private bool isGoalKeeper;
    public float goalKeeperBoundMinX;
    public float goalKeeperBoundMaxX;
    public float goalKeeperBoundMinY;
    public float goalKeeperBoundMaxY;

    public PlayerType GetPlayerType()
    {
        return playerType;
    }

    public float GetMoverSpeed()
    {
        return moverSpeed;
    }

    public bool IsGoalKeeper()
    {
        return isGoalKeeper;
    }
}
