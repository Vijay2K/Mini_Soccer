using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayGameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private CanvasGroup gameOverCanvasGroup;
    [SerializeField] private Color redColor;
    [SerializeField] private Color blueColor;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private Button exitBtn;

    private void Start() 
    {
        GameManager.Instance.OnGameOver += Display;

        gameOverCanvasGroup.alpha = 0;
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
        }

        UpdateDisplay(winnerName, color);
    }

    private void UpdateDisplay(string winner, Color color)
    {
        gameOverPanel.GetComponent<Image>().color = color;
        winnerText.text = winner;

        winnerText.transform.localScale = Vector2.zero;
        exitBtn.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);

        StartCoroutine(DisplayAnimation());
    }

    private IEnumerator DisplayAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        float lerp = 0;

        while(lerp < 1)
        {
            lerp += Time.deltaTime;
            gameOverCanvasGroup.alpha = Mathf.Lerp(0, 1, lerp);
            yield return null;
        }

        AudioManager.Instance.Play(SoundType.CrowdSound);
        yield return Utils.PopupAnim(winnerText.gameObject, 2f);
        exitBtn.gameObject.SetActive(true);
    }
}
