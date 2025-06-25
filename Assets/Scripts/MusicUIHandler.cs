using UnityEngine;

public class MusicUIHandler : MonoBehaviour
{
    public void TurnMusicOn()
    {
        if (BackgroundMusic.Instance != null)
            BackgroundMusic.Instance.TurnOnMusic();
    }

    public void TurnMusicOff()
    {
        if (BackgroundMusic.Instance != null)
            BackgroundMusic.Instance.TurnOffMusic();
    }
}
