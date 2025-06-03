using UnityEngine;
using UnityEngine.UI;

public class ScoreUIConnector : MonoBehaviour
{
    public Text newScoreText;

    void Start()
    {
        if (ScoreManager.instance != null && newScoreText != null)
        {
            ScoreManager.instance.scoreText = newScoreText;
            ScoreManager.instance.UpdateScoreUI(); // Cập nhật lại UI
        }
    }
}
