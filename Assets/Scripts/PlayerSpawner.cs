using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    public Slider healthSlider; 

    void Start()
    {
        if (CharacterSelector.Instance != null)
        {
            GameObject player = Instantiate(CharacterSelector.Instance.GetSelectedCharacter(), transform.position, Quaternion.identity);

            
            FollowCamera camFollow = Camera.main.GetComponent<FollowCamera>();
            if (camFollow != null)
                camFollow.SetTarget(player.transform);

            
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            if (health != null)
                health.healthSlider = healthSlider;
        }
    }
}
