using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject carrot;
    public GameObject block;
    public float maxX;
    public Transform spawnPoints;
    public float spawnRate;
    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI carrotScoreText;
    public GameObject carrotCollectEffect;

    private int score = 0;
    private int carrotScore = 0;

    private bool gameStarted = false;

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
            
            tapText.SetActive(false);
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.75f, spawnRate);
        InvokeRepeating("SpawnCarrot", 1f, spawnRate);
    }

    void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoints.position;

        spawnPos.x = Random.Range(-maxX, maxX);
        
        Instantiate(block, spawnPos, Quaternion.identity);

        score++;
        scoreText.text = score.ToString();
    }

    void SpawnCarrot()
    {
        Vector3 carrotPos = spawnPoints.position;

        carrotPos.x = Random.Range(-maxX, maxX);

        Instantiate(carrot, carrotPos, Quaternion.identity);
    }

    public void AddCarrotScore(int amount)
    {
        carrotScore++;
        carrotScoreText.text = carrotScore.ToString();
    }

    public void PlayCarrotCollectFeedback(Vector3 position)
    {
        if (carrotCollectEffect != null)
        {
            Instantiate(carrotCollectEffect, position, Quaternion.identity);
        }
    }
}
