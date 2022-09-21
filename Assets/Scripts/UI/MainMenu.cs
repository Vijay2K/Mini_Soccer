using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Button playBtn;

    public event Action OnGameStart;

    private void Start() 
    {
        playBtn.onClick.AddListener(Play);
    }

    private void Play() 
    {
        StartCoroutine(GameStartDelay());
    }

    private IEnumerator GameStartDelay()
    {
        animator.SetTrigger("Play");
        yield return new WaitForSeconds(1f);
        OnGameStart?.Invoke();
    }
}
