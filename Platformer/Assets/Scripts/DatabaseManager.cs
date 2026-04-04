using UnityEngine;
using SQLite;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Rendering;

public class HighScore
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public float CompletionTime { get; set; }
}

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance { get; private set; }

    private string dbPath;
    private SQLiteConnection dbConnection;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SetDatabasePath();
        InitializeDatabase();
    }
    
    void SetDatabasePath()
    {
        dbPath = Path.Combine(Application.persistentDataPath, "gamedata.db");
    }

    void InitializeDatabase()
    {
        dbConnection = new SQLiteConnection(dbPath);
        CreateHighScoreTable();
    }

    void CreateHighScoreTable()
    {
        dbConnection.CreateTable<HighScore>();
        Debug.Log("High Score table created at: " + dbPath);
    }

    public void SaveHighScore(string playerName, int score, float completionTime)
    {
        HighScore newScore = new HighScore
        {
            PlayerName = playerName,
            Score = score,
            CompletionTime = completionTime
        };

        dbConnection.Insert(newScore);
        Debug.Log("High Score saved: " + playerName + " - " + score);
    }

    public List<HighScore> GetHighScores(int count)
    {
        return dbConnection.Table<HighScore>().OrderByDescending(s => s.Score).ThenBy(s => s.CompletionTime).ToList();
    }
}
