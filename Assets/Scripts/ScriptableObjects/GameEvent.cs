using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event")]
public class GameEvent : ScriptableObject
{
    public List<GameEventListener> listeners = new List<GameEventListener>();

    public void Raise(Component sender, object data)
    {
        for (int i = 0; i < listeners.Count; i++)
        {
            listeners[i].OnEventRaised(sender, data);
        }
    }

    public void RegisterListeners(GameEventListener eventListener)
    {
        if(!listeners.Contains(eventListener))
        {
            listeners.Add(eventListener);
        }
    }

    public void UnRegisterListeners(GameEventListener eventListener)
    {
        if(listeners.Contains(eventListener))
        {
            listeners.Remove(eventListener);
        }
    }
}
