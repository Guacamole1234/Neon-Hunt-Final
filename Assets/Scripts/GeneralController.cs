using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GeneralController : MonoBehaviour
{
    public static GeneralController instance;
    
    [SerializeField] GameObject enemiesParent;
    int enemiesAmount;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI enemiesText;


    [SerializeField] GameObject[] textEtiquettes;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI finalHighScoreText;

    [SerializeField] GameObject restartButton;

    [SerializeField] GameObject wonText;
    [SerializeField] GameObject loseText;

    public bool gameActive = false;

    public bool playerWon;
    float scoreMultiply = 10f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        wonText.SetActive(false);
        loseText.SetActive(false);

        restartButton.gameObject.SetActive(false);

        foreach (var textObject in textEtiquettes)
        {
            textObject.gameObject.SetActive(false);
        }

        finalHighScoreText.gameObject.SetActive(false);
        finalScoreText.gameObject.SetActive(false);

        gameActive = true;

        Cursor.lockState = CursorLockMode.Locked;

        enemiesAmount = enemiesParent.transform.childCount;
        enemiesText.text = enemiesAmount.ToString();
    }

    public void CheckEnemies()
    {
        enemiesAmount--;
        enemiesText.text = enemiesAmount.ToString();
        if (enemiesAmount <= 0)
        {
            playerWon = true;
            StartRestart();
        }
    }

    public void StartRestart()
    {
        gameActive = false;

        if (playerWon)
            {
                float timeAddScore = TimerBehaviour.instance.currentTimer * scoreMultiply;
                ScoreManagerBehaviour.instance.AddScore(timeAddScore);
                wonText.SetActive(true);
            }
            else
            {
                loseText.SetActive(true);
            }
            
            restartButton.SetActive(true);
            finalHighScoreText.text = PlayerPrefs.GetFloat("HighScore").ToString("0000");
            finalScoreText.text = ScoreManagerBehaviour.instance.currentScore.ToString("0000");

            foreach (var textObject in textEtiquettes)
            {
                textObject.gameObject.SetActive(true);
            }

            finalHighScoreText.gameObject.SetActive(true);
            finalScoreText.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            EventSystem.current.SetSelectedGameObject(restartButton.gameObject);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
