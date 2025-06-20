using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject carrot;
    public GameObject block;
    public GameObject carrotCollectEffect;
    public GameObject tapText;
    public GameObject playerDeathEffect;
    public GameObject gameOverPanel;

    public Transform spawnPoints;

    public float maxX;
    public float spawnRate;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI carrotScoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalCarrotScoreText;
    public TextMeshProUGUI finalTimeText;

    private int score = 0;
    private int carrotScore = 0;
    private int lastAwardedSecond = 0;

    private float survivalTime = 0f;

    private bool gameStarted = false;
    private bool timerRunning = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            timerRunning = true;
            tapText.SetActive(false);
        }

        if (timerRunning)
        {
            survivalTime += Time.deltaTime;
            UpdateTimerUI();

            int currentSecond = Mathf.FloorToInt(survivalTime);
            if (currentSecond > lastAwardedSecond)
            {
                int pointsToAdd = currentSecond - lastAwardedSecond;
                AddBlockScore(pointsToAdd);
                lastAwardedSecond = currentSecond;
            }
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.75f, spawnRate);
        InvokeRepeating("SpawnCarrot", 1f, spawnRate);
    }

    // Crate spawning
    void SpawnBlock()
    {
        Vector3 blockPos = spawnPoints.position;

        blockPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, blockPos, Quaternion.identity);
    }

    // Block Crate avoiding score
    public void AddBlockScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    // Spawning of Carrot
    void SpawnCarrot()
    {
        Vector3 carrotPos = spawnPoints.position;

        carrotPos.x = Random.Range(-maxX, maxX);

        Instantiate(carrot, carrotPos, Quaternion.identity);
    }

    // Carrot collection score
    public void AddCarrotScore(int amount)
    {
        carrotScore++;
        carrotScoreText.text = carrotScore.ToString();
    }

    // Visual Effect played on player death
    public void PlayerDeathEffectFeedback(Vector3 position)
    {
        if (playerDeathEffect != null)
        {
            Instantiate(playerDeathEffect, position, Quaternion.identity);
        }
    }

    // Visual Effect on Carrot Collection
    public void PlayCarrotCollectFeedback(Vector3 position)
    {
        if (carrotCollectEffect != null)
        {
            Instantiate(carrotCollectEffect, position, Quaternion.identity);
        }
    }

    // Stop Timer
    public void StopTimer()
    {
        timerRunning = false;
    }

    // Time UI Update
    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = survivalTime.ToString("F1") + "s";
        }
    }

    // Game Over Panel
    public void ShowGameOverPanel()
    {
        StopTimer();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        else if (finalScoreText != null)
        {
            finalScoreText.text = scoreText.text;
        }

        else if (finalCarrotScoreText != null)
        {
            finalCarrotScoreText.text = carrotScoreText.text;
        }

        else if (finalTimeText)
        {
            finalTimeText.text = timerText.text;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
