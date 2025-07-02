using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public static CharacterSelector Instance;

    public GameObject[] characterPrefabs; // Gán 4 nhân vật trong Inspector
    public int selectedCharacterIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại qua các scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetCharacterIndex(int index)
    {
        selectedCharacterIndex = index;
        Debug.Log("Selected character: " + index);
    }

    public GameObject GetSelectedCharacter()
    {
        return characterPrefabs[selectedCharacterIndex];
    }
}
