using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event System.Action OnGameStarted;
    
    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            Instance = this;
        }

        Instance = this;
    }

    private void Start() 
    {
        OnGameStarted?.Invoke();
    }
}
