using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStartCountdown : MonoBehaviour
{
    public event System.Action<int> OnCountDownChanged;
    public event System.Action OnCountDownStopped;

    private int count = 3;
    private System.Action resetAnim;

    private void Start() 
    {
        FindObjectOfType<MainMenu>().OnGameStart += StartCountDown;
    }

    private void StartCountDown()
    {
        StartCoroutine(StartCountDownDelay());
    }

    private IEnumerator StartCountDownDelay() 
    {
        yield return new WaitForSeconds(0.5f);
        while(count > 0)
        {
            OnCountDownChanged?.Invoke(count);
            count--;
            AudioManager.Instance.Play(SoundType.Beep);
            yield return new WaitForSeconds(1f);
            resetAnim?.Invoke();
        }

        if(count <= 0)
        {
            OnCountDownStopped?.Invoke();
        }
    }

    public void ResetCounterAnimSettings(System.Action reset)
    {
        this.resetAnim = reset;
    }        
}
