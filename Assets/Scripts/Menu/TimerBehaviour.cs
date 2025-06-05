using UnityEngine;
using TMPro;
using UnityEngine.ProBuilder.Shapes;

public class TimerBehaviour : MonoBehaviour
{
    public static TimerBehaviour instance;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float maxTimer;
    public float currentTimer;

    float minutes;
    float seconds;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentTimer = maxTimer;
    }

    void Update()
    {
        if (GeneralController.instance.gameActive)
        {
            currentTimer -= Time.deltaTime;
            minutes = (int)((currentTimer % 3600) / 60);
            seconds = (int)(currentTimer % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }
}
