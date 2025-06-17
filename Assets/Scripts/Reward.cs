using UnityEngine;

public class Reward : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindAnyObjectByType<ScoreManager>();

            if (scoreManager != null)
            {
                scoreManager.AddScore(1);
                Debug.Log("Reward collected → Score increased");
            }
            else
            {
                Debug.LogWarning("ScoreManager not found!");
            }

            Destroy(gameObject); // chỉ destroy khi đã kiểm tra đúng
        }
    }
}
