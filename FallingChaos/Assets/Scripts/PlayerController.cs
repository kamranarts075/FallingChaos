using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Block"))
        {
            GameManager.Instance.PlayerDeathEffectFeedback(transform.position);
            Destroy(gameObject);
            GameManager.Instance.StopTimer();
            GameManager.Instance.ShowGameOverPanel();
            gameObject.SetActive(false);
        }

        else if (other.gameObject.CompareTag("Carrot"))
        {
            GameManager.Instance.PlayCarrotCollectFeedback(transform.position);
            Destroy(other.gameObject);
            GameManager.Instance.AddCarrotScore(1);
        }
    }
}
