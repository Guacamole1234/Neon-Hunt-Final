using UnityEngine;
using TMPro;

public class ScoreManagerBehaviour : MonoBehaviour
{
    public static ScoreManagerBehaviour instance;
    
    [HideInInspector] public float currentScore = 0f;
    [SerializeField] float scoreLossPerBullet;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void ReduceScore()
    {
        currentScore -= scoreLossPerBullet;
        UpdateScoreText();
    }

    public void AddScore(float amount)
    {
        currentScore += amount;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString("0000");

        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (PlayerPrefs.GetFloat("HighScore") < currentScore)
            {
                PlayerPrefs.SetFloat("HighScore", currentScore);
            }
        }
        else
        {
            PlayerPrefs.SetFloat("HighScore", currentScore);
        }
    }
}
