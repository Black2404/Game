using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayAgain()
    {
        ScoreManager.instance?.ResetScore(); // Reset trước
        SceneManager.LoadScene("scene1");    // Sau đó load lại
    }



    public void QuitGame()
    {
        Debug.Log("Thoát game...");
        Application.Quit();
    }
}
