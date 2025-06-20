using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnInterval = 2f;
    public Transform[] spawnPoints;

    void Start()
    {
        InvokeRepeating("SpawnCloud", 0f, spawnInterval);
    }

    void SpawnCloud()
    {
        if (spawnPoints.Length == 0)

        {
            Debug.Log("No spawn points available.");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(cloudPrefab, spawnPoint.position, Quaternion.identity);

        Debug.Log("Spawned cloud at: " + spawnPoint.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach (Transform spawnPoint in spawnPoints)
        {
            if (spawnPoint != null)
            {
                Gizmos.DrawSphere(spawnPoint.position, 0.5f);
            }
        }
    }
}
