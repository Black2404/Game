using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;       // tốc độ di chuyển gốc
    public float jumpForce = 5f;       // lực nhảy gốc
    private Rigidbody2D rbody;
    private Animator anim;
    private bool grounded = false;
    private RewardManager rewardManager;
    private SpriteRenderer spriteRenderer;

    private int moveState = 0;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rewardManager = FindObjectOfType<RewardManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        State();

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(Vector3.left);
            spriteRenderer.flipX = true; // lật mặt trái
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(Vector3.right);
            spriteRenderer.flipX = false; // mặt phải
        }
    }

    void Jump()
    {
        rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetBool("Jump", true);
        FindObjectOfType<SoundManager>().PlayJump();
    }


    void Move(Vector3 dir)
    {
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }

    void State()
    {
        if (moveState == 0)
        {
            anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Run", true);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetBool("Jump", false);
        }
        else if (col.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<PlayerHealth>().TakeDamage(50);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Reward"))
        {
            rewardManager.CollectReward(col.gameObject);
        }
        else if (col.CompareTag("Door"))
        {
            if (rewardManager.allCollected)
            {
                Debug.Log("Đủ reward → chuyển scene");
                Scene currentScene = SceneManager.GetActiveScene();

                if (currentScene.name == "scene1")
                {
                    SceneManager.LoadScene("scene2");
                }
                else if (currentScene.name == "scene2")
                {
                    SceneManager.LoadScene("win");
                }
            }
            else
            {
                Debug.Log("Chưa đủ reward → KHÔNG được vào cửa");
            }
        }
    }

}
