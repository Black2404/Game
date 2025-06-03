using UnityEngine;

public class Reward : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(1);
            }
            else
            {
                Debug.LogWarning("ScoreManager not found!");
            }

            Destroy(gameObject); 
        }
    }
}
