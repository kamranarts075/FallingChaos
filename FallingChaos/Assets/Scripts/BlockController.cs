using UnityEngine;

public class BlockController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -6f)
        {
            GameManager.Instance.AddBlockScore(1);

            Destroy(gameObject);
        }
    }
}