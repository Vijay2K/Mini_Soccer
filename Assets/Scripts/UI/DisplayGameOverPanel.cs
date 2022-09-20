using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayGameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Color redColor;
    [SerializeField] private Color blueColor;
    [SerializeField] private Color greenColor;
    [SerializeField] private TextMeshProUGUI winnerText;

    private void Start() 
    {
        GameManager.Instance.OnGameOver += Display;
    }

    private void Display(PlayerType winner)
    {
        string winnerName;
        Color color;

        switch(winner)
        {
            default:
            case PlayerType.Player_1:
                winnerName = "Red\nWins";
                color = redColor;
                break;
            case PlayerType.Player_2:
                winnerName = "Blue\nWins";
                color = blueColor;
                break;
            case PlayerType.NONE:
                winnerName = "Match\nDraw";
                color = greenColor;
                break;
        }

        UpdateDisplay(winnerName, color);
    }

    private void UpdateDisplay(string winner, Color color)
    {
        gameOverPanel.GetComponent<Image>().color = color;
        winnerText.text = winner;
        gameOverPanel.SetActive(true);
    }
}
