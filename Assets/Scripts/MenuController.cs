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
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

}
