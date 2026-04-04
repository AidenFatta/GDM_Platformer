using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts
        ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisplayHighScores();
    }

    void DisplayHighScores()
    {
        List<HighScore> topScores = DatabaseManager.Instance.GetHighScores(5);

        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < topScores.Count)
            {
                HighScore score = topScores[i];
                scoreTexts[i].text = $"{score.PlayerName}: {score.Score} pts - {score.CompletionTime:F2} sec";
                Debug.Log($"Displaying score for position {i + 1}: {score.PlayerName} - {score.Score} pts - {score.CompletionTime:F2} sec");
            }
            else
            {
                scoreTexts[i].text = (i + 1) + " No Score";
                Debug.Log("No score for position " + (i + 1));
            }
        }
    }
}
