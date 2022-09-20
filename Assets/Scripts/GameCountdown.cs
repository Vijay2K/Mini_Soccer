using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCountdown : MonoBehaviour
{
    public event Action OnCountdownStopped;
    public event Action<int> OnCountdownChanged;

    [SerializeField] private int maxTime;

    private void Start() 
    {
        FindObjectOfType<GameStartCountdown>().OnCountDownStopped += StartCountDown;
    }

    private void StartCountDown()
    {
        AudioManager.Instance.Play(SoundType.shortWhistle);
        StartCoroutine(CountdownDelay());
    }

    private IEnumerator CountdownDelay()
    {
        yield return new WaitForSeconds(2f);
        while(maxTime > 0)
        {
            maxTime--;
            OnCountdownChanged?.Invoke(maxTime);
            yield return new WaitForSeconds(1f);
        }

        if(maxTime <= 0)
        {
            OnCountdownStopped?.Invoke();
        }
    }
}
