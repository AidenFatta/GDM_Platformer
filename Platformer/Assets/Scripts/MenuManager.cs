using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   public void OnStartClick()
    {
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene("GameScene");     
    }

    public void OnScoreClick()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void OnExitClick()
    {
        Debug.Log("Exiting the game...");
        Application.Quit();
    }
    public void OnBackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
