using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardManager : MonoBehaviour
{
    private int totalRewards;
    private int collectedRewards = 0;

    void Start()
    {
        // Đếm tất cả reward trong scene
        totalRewards = GameObject.FindGameObjectsWithTag("Reward").Length;
        Debug.Log("Total rewards: " + totalRewards);
    }

    public void CollectReward(GameObject reward)
    {
        collectedRewards++;
        Destroy(reward);
        Debug.Log("Collected: " + collectedRewards + "/" + totalRewards);

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
