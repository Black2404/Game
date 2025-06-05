using UnityEngine;

public class Reward : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ScoreManager>().AddScore(1);
            Destroy(gameObject);
        }
        else
            {
                Debug.LogWarning("ScoreManager not found!");
            }

            Destroy(gameObject); 
        }
    }
