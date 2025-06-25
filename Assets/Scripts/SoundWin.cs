using UnityEngine;

public class SoundWin  : MonoBehaviour
{
    public AudioClip winSound;

    void Start()
    {
        if (BackgroundMusic.Instance != null)
        {
            BackgroundMusic.Instance.StopMusic(); // Tắt nhạc nền nếu đang phát
        }

        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = winSound;
        audio.Play();
    }
}
