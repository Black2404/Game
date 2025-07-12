using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic Instance;

    private AudioSource audioSource;
    private readonly string[] allowedScenes = { "Main","Menu", "scene1", "scene2" };

    private const string MusicEnabledKey = "MusicEnabled";
    private const string MusicVolumeKey = "MusicVolume";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;

        float savedVolume = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
        bool isEnabled = PlayerPrefs.GetInt(MusicEnabledKey, 1) == 1;

        audioSource.volume = savedVolume;

        if (isEnabled && savedVolume > 0f)
            audioSource.Play();

        CheckScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckScene(scene.name);
    }

    void CheckScene(string name)
    {
        bool allowed = false;
        foreach (var s in allowedScenes)
        {
            if (name == s)
            {
                allowed = true;
                break;
            }
        }

        if (!allowed)
        {
            audioSource.Stop();
            Destroy(gameObject); // huỷ nhạc nền nếu scene không thuộc danh sách cho phép
        }
    }

    public void TurnOnMusic()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();

        PlayerPrefs.SetInt(MusicEnabledKey, 1);
        PlayerPrefs.Save();
    }

    public void TurnOffMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();

        PlayerPrefs.SetInt(MusicEnabledKey, 0);
        PlayerPrefs.Save();
    }

    public void StopMusic()
    {
        if (audioSource.isPlaying)
            audioSource.Stop();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(MusicVolumeKey, volume);
        PlayerPrefs.Save();

        if (volume == 0 && audioSource.isPlaying)
            audioSource.Pause();
        else if (volume > 0 && !audioSource.isPlaying && PlayerPrefs.GetInt(MusicEnabledKey, 1) == 1)
            audioSource.Play();
    }

    public bool IsMusicOn() => audioSource.isPlaying;
    public float GetVolume() => audioSource.volume;
}
