using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI player_1_scoreText;
    [SerializeField] private TextMeshProUGUI player_2_scoreText;

    private void Start() 
    {
        FindObjectOfType<GameCountdown>().OnCountdownChanged += UpdateCountDownTextUI;
        ScoreManager.Instance.OnScoreChanged += UpdatePlayerScoreTextUI;
    }

    private void UpdateCountDownTextUI(int countDown)
    {
        countdownText.text = countDown.ToString();
    }

    private void UpdatePlayerScoreTextUI(int player_1_score, int player_2_score)
    {
        player_1_scoreText.text = player_1_score.ToString();
        player_2_scoreText.text = player_2_score.ToString();
    }
}
