using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // Singleton để gọi ở mọi nơi

    public AudioClip jumpSound;
    public AudioClip collectSound;
    public AudioClip winSound;

    private AudioSource audioSource;

    void Awake()
    {
        // Tạo Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không phá hủy khi chuyển scene
        }
        else
        {
            Destroy(gameObject); // Nếu đã có rồi thì phá bản mới
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void PlayCollect()
    {
        audioSource.PlayOneShot(collectSound);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(winSound);
    }

    public void SetSFXVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public float GetSFXVolume()
    {
        return audioSource.volume;
    }
}
