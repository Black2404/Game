using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        if (ScoreManager.instance != null)
        {
            int score = ScoreManager.instance.GetScore();
            scoreText.text = "Score: " + score;
            Debug.Log("Hiển thị điểm Game Over: " + score);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy ScoreManager.instance!");
        }
    }
}
