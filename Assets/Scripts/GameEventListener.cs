using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomUnityEvent : UnityEvent<Component, object>{}

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private CustomUnityEvent response;

    private void OnEnable() 
    {
        gameEvent.RegisterListeners(this);
    }

    private void OnDisable() 
    {
        gameEvent.UnRegisterListeners(this);
    }

    public void OnEventRaised(Component sender, object data)
    {
        response?.Invoke(sender, data);
    }
}
