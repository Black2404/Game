using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private int score = 0;
    private bool scoreTextInitialized = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject); // tránh duplicate nếu quay lại scene
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreTextInitialized = false; // đánh dấu là cần gán lại text
    }

    void Update()
    {
        // Nếu chưa gán text sau khi chuyển scene thì gán
        if (!scoreTextInitialized)
        {
            GameObject txtObj = GameObject.Find("scoreText");
            if (txtObj != null)
            {
                scoreText = txtObj.GetComponent<Text>();
                scoreTextInitialized = true;
                UpdateScoreUI();
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (scoreText == null)
        {
            GameObject txtObj = GameObject.Find("scoreText");
            if (txtObj != null)
            {
                scoreText = txtObj.GetComponent<Text>();
            }
        }

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        Debug.Log("Score updated: " + score);
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
