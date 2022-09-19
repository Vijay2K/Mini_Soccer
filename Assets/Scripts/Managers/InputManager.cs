using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    [SerializeField] private InputData[] inputDataArray;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public float GetJoystickHorizontal(PlayerType playerType)
    {
        return GetJoystickInput(playerType).Horizontal;
    }

    public float GetJoystickVertical(PlayerType playerType)
    {
        return GetJoystickInput(playerType).Vertical;
    }

    public DynamicJoystick GetJoystickInput(PlayerType playerType)
    {
        foreach(InputData inputData in inputDataArray)
        {
            if(inputData.playerType != playerType) continue;
            return inputData.joystick;
        }

        return null;
    }
}
