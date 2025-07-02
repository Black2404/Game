using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 30f;
    public Text timerText;
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            GameOver();
        }

        UpdateTimerDisplay();
    }
    void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = seconds.ToString();
    }
    void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("gameover");
    }
}
