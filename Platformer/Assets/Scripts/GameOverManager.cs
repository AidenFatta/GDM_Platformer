using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TMP_InputField nameInputField;


    private void Start()
    {
        scoreText.text = $"{GameManager.Instance.score}";
    }

    public void OnSubmitScore()
    {
        string playerName = nameInputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Player";
        }

        int finalScore = GameManager.Instance.score;
        float completionTime = Time.timeSinceLevelLoad;

        DatabaseManager.Instance.SaveHighScore(playerName, finalScore, completionTime);
        SceneManager.LoadScene("HighScore");
    }

    public void OnRetryClick()
    {
        
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");
        CoinPoolManager.Instance.ResetAllCoins();
    }

    public void OnTitleClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
