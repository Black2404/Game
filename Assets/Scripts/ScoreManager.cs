using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int score = 0;
    private Text scoreText;

    void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Đăng ký ngay khi tạo
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Đăng ký lại nếu script bị disable/enable
    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Đợi 1 frame để UI kịp tạo
        Invoke(nameof(FindAndAssignScoreText), 0.1f);
    }

    private void FindAndAssignScoreText()
    {
        GameObject go = GameObject.Find("scoreText");
        if (go != null)
        {
            scoreText = go.GetComponent<Text>();
            if (scoreText != null)
            {
                scoreText.text = "Score: " + score;
                Debug.Log("scoreText gán thành công.");
            }
        }
        else
        {
            Debug.LogWarning("Không tìm thấy scoreText trong scene: " + SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int value)
    {
        score += value;

        if (scoreText == null)
        {
            FindAndAssignScoreText(); // Thử tìm lại nếu mất
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void ResetScore()
    {
        score = 0;

        if (scoreText != null)
            scoreText.text = "Score: 0";
    }

    public int GetScore() => score;
}
