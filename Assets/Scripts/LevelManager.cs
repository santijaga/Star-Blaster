using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }

        SceneManager.LoadScene("GameScene");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", 2));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(name);
    }
}
