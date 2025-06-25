using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("scene1");
    }

    public void PlayAgain()
    {
        ScoreManager.instance.ResetScore();
        SceneManager.LoadScene("scene1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
