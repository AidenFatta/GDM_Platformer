using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = $"{finalScore}";
    }

    public void OnRetryClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnTitleClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
