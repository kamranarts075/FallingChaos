using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoints;
    public float spawnRate;
    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private bool gameStarted = false;

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
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoints.position;

        spawnPos.x = Random.Range(-maxX, maxX);
        
        Instantiate(block, spawnPos, Quaternion.identity);
        
        score++;
        
        scoreText.text = score.ToString();
    }
}
