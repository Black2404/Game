using UnityEngine;
using UnityEngine.SceneManagement;

public class Reward : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger từ: " + other.name); 

        if (other.CompareTag("Player"))
        {
            Debug.Log("Đã chạm Player");

            var scoreManager = ScoreManager.instance;

            if (scoreManager == null)
            {
                Debug.LogWarning("ScoreManager.instance = null");
            }
            else
            {
                Debug.Log("ScoreManager instance tồn tại");
                scoreManager.AddScore(1);
                Debug.Log("Collected reward → score = " + scoreManager.GetScore());
            }

            Destroy(gameObject);
        }
    }
}
