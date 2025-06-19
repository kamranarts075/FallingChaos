using UnityEngine;

public class CarrotController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
