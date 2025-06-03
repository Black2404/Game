using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;
    RewardManager rewardManager;

    bool walking, grounded = false;
    float speed = 30f;
    float jumpForce = 150f;  // Lực nhảy
    float walkDuration = 0f;  // Thời gian đi bộ liên tục
    int moveState;
    public GameObject gameOverText;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (gameOverText != null)
            gameOverText.SetActive(false);

        rewardManager = Object.FindAnyObjectByType<RewardManager>();
        if (rewardManager == null)
            Debug.LogWarning("RewardManager not found in scene!");

        rbody.gravityScale = 30f;
    }

    void Move(Vector3 dir)
    {
        walking = true;
        walkDuration += Time.fixedDeltaTime;

        transform.Translate(dir * speed * Time.fixedDeltaTime);

        if (walkDuration < 3f)
        {
            speed = Mathf.Min(speed + 0.025f, 80f);
        }
        else
        {
            speed = 40f;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, 0);
            rbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
            anim.SetBool("Jump", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene("gameover");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetBool("Jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Reward"))
        {
            if (rewardManager != null)
            {
                rewardManager.CollectReward(collision.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    void State()
    {
        switch (moveState)
        {
            case 1:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                Move(Vector3.right);
                break;
            case 2:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),
                    transform.localScale.y, transform.localScale.z);
                Move(Vector3.left);
                break;
            default:
                walking = false;
                walkDuration = 0f;
                speed = 40f;
                anim.SetBool("Run", false);
                break;
        }
    }

    void Update()
    {
        State();
        Jump();
    }

    private void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
            moveState = 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveState = 2;
    }
}
