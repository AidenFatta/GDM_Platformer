using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<int> OnHealthChanged;
    public event Action<int> OnScoreChanged;
    public event Action OnGameOver;

    public int score = 0;
    public int health = 100;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);
        OnHealthChanged?.Invoke(health);

        if (health <= 0)
        {
            Debug.Log("Game Over!");
            OnGameOver?.Invoke();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
        OnScoreChanged?.Invoke(score);
    }

    public void ResetGame()
    {
        score = 0;
        health = 100;
        OnHealthChanged?.Invoke(health);
        OnScoreChanged?.Invoke(score);
    }
}
