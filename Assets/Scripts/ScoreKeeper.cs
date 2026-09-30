using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    static ScoreKeeper instance;

    private void Awake()
    {
        ManageSingletone();
    }

    void ManageSingletone()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        score = Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }
}
