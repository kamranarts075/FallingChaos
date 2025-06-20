using UnityEngine;

public class CloudController : MonoBehaviour
{
    public float floatStrength = 0.5f;
    public float floatDistance = 0.5f;
    public float moveSpeed = 2.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time) * floatDistance;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }
}
