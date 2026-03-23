using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText.text = $"{GameManager.Instance.score}";
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
