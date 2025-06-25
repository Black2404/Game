using UnityEngine;

public class Fan : MonoBehaviour
{
    public float speed = 2f;           // tốc độ di chuyển
    public float moveDistance = 3f;    // khoảng cách đi được mỗi bên

    private Vector3 startPos;
    private int direction = 1;         // 1 = phải, -1 = trái

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Di chuyển ngang
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);

        // Nếu vượt giới hạn trái/phải → đảo hướng
        if (Mathf.Abs(transform.position.x - startPos.x) >= moveDistance)
        {
            direction *= -1; // Đổi chiều
        }
    }
}
