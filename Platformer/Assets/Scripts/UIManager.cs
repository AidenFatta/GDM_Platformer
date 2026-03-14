using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;

    private void OnEnable()
    {
        GameManager.Instance.OnHealthChanged += UpdateHealth;
        GameManager.Instance.OnScoreChanged += UpdateScore;
        GameManager.Instance.OnGameOver += HandleGameOver;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnHealthChanged -= UpdateHealth;
        GameManager.Instance.OnScoreChanged -= UpdateScore;
        GameManager.Instance.OnGameOver -= HandleGameOver;
    }
    private void UpdateHealth(int newHealth)
    {
        healthText.text = $"{newHealth}";
    }
    private void UpdateScore(int newScore)
    {
        scoreText.text = $"{newScore}";
    }

    void HandleGameOver()
    {
        PlayerPrefs.SetInt("FinalScore", GameManager.Instance.score);
        SceneManager.LoadScene("GameOver");
    }
}
