using UnityEngine;

public class RewardManager : MonoBehaviour
{
    private int totalRewards;
    private int collectedRewards;
    public bool allCollected = false;

    void Start()
    {
        GameObject[] rewards = GameObject.FindGameObjectsWithTag("Reward");
        totalRewards = rewards.Length;
        collectedRewards = 0;
    }

    public void CollectReward(GameObject reward)
    {
        collectedRewards++;

        //Phát âm thanh khi thu thập
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayCollect();
        }

        // Có thể phá hủy reward ở đây nếu cần
        Destroy(reward);

        if (collectedRewards >= totalRewards)
        {
            allCollected = true;
            Debug.Log("Đã ăn hết tất cả vật phẩm!");
        }
    }

}
