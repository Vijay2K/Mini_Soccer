using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Game Total Timer Ui Reference")]
    [SerializeField] private TextMeshProUGUI countdownText;
    
    [Header("Player Score Ui Reference")]
    [SerializeField] private TextMeshProUGUI player_1_scoreText;
    [SerializeField] private TextMeshProUGUI player_2_scoreText;

    [Header("Game Start counter Ui Reference")]
    [SerializeField] private TextMeshProUGUI gameStartCounterText;
    [SerializeField] private CanvasGroup gameStartCounterPanelCanvas;
    [SerializeField] private Animator gameStartCounterAnimator;

    private GameStartCountdown gameStartCountdown;
    private GameCountdown gameCountdown;

    private void Awake() 
    {
        gameStartCountdown = FindObjectOfType<GameStartCountdown>();
        gameCountdown = FindObjectOfType<GameCountdown>();

        EnableGameStartCounterPanel();
    }

    private void OnEnable() 
    {
        gameStartCountdown.OnCountDownChanged += UpdateGameStartCounterUI;
    }

    private void Start() 
    {
        gameCountdown.OnCountdownChanged += UpdateCountDownTextUI;
        gameStartCountdown.OnCountDownStopped += FadeOutGameStartCounterPanel;

        ScoreManager.Instance.OnScoreChanged += UpdatePlayerScoreTextUI;

        FindObjectOfType<GoldenGoal>().OnGoldenGoalStart += UpdateCountDownTextOnGoldenGoalStarted;

        UpdateCountDownTextUI(gameCountdown.GetMaxTimer());
    }

    private void UpdateCountDownTextUI(int countDown)
    {
        countdownText.text = countDown.ToString();
    }

    private void UpdateCountDownTextOnGoldenGoalStarted()
    {
        StartCoroutine(UpdateGoldenGoalTextDelay());
    }

    private IEnumerator UpdateGoldenGoalTextDelay()
    {
        yield return new WaitForSeconds(2f);
        countdownText.text = "Golden\nGoal";
    }

    private void UpdateGameStartCounterUI(int count)
    {        
        gameStartCounterText.text = count.ToString();
        gameStartCounterAnimator.SetTrigger("Pop");
        gameStartCountdown.ResetCounterAnimSettings(ResetGameStartAnim);
    }

    private void ResetGameStartAnim()
    {
        gameStartCounterAnimator.Rebind();
        gameStartCounterAnimator.Update(0);
    }

    private void EnableGameStartCounterPanel()
    {
        gameStartCounterPanelCanvas.gameObject.SetActive(true);
    }

    private void FadeOutGameStartCounterPanel()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float lerp = 0;
        while(gameStartCounterPanelCanvas.alpha > 0)
        {
            lerp += Time.deltaTime;
            gameStartCounterPanelCanvas.alpha = Mathf.Lerp(1, 0, lerp);
            yield return null;
        } 

        if(gameStartCounterPanelCanvas.alpha == 0)
        {
            gameStartCounterPanelCanvas.gameObject.SetActive(false);
        }               
    }

    private void UpdatePlayerScoreTextUI(int player_1_score, int player_2_score)
    {
        player_1_scoreText.text = player_1_score.ToString();
        player_2_scoreText.text = player_2_score.ToString();
    }
}
