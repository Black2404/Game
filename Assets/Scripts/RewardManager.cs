using UnityEngine.SceneManagement;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance { get; private set; }

    private int totalRewards;
    private int collectedRewards = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // Uncomment nếu bạn muốn giữ qua nhiều scene
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        totalRewards = GameObject.FindGameObjectsWithTag("Reward").Length;
        Debug.Log("Total rewards: " + totalRewards);
    }

    public void CollectReward(GameObject reward)
    {
        collectedRewards++;
        Destroy(reward);
        Debug.Log($"Collected: {collectedRewards}/{totalRewards}");

        if (collectedRewards >= totalRewards)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            Debug.Log("No more scenes to load.");
        }
    }
}
