using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayManager playManager;
    public PlayerManager playerManager;
    public SoundManager soundManager;

    public float speed;
    public float jumpForce;
    public int maxJumps;
    public int curJumps;
    [Space]
    public Rigidbody2D rb;
    public bool top;
    private bool canSwitch;

    private bool gameIsOn;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curJumps = maxJumps;
        canSwitch = true;
    }

    void Update()
    {
        if (playManager.GameIsOn)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        }

        if(transform.position.y >= 7)
        {
            playerManager.GameIsOver();
        }
        if(transform.position.y <= -7)
        {
            playerManager.GameIsOver();
        }
    }

    public void UpdateSpeed()
    {
        speed *= playManager.gameSpeed;
    }

    public void Jump()
    {
        if (playManager.GameIsOn)
        {
            if (curJumps > 0)
            {
                if (!top)
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
                else
                {
                    rb.velocity = Vector2.down * jumpForce;
                }
                if (soundManager.audioIsOn)
                {
                    soundManager.jumpAudio.Play();
                }
            }

            curJumps--;
        }
    }

    public void SwitchGravity()
    {
        if (playManager.GameIsOn)
        {
            if (canSwitch)
            {
                canSwitch = false;
                rb.gravityScale *= -1;
                Rotation();

                if (soundManager.audioIsOn)
                {
                    soundManager.gravityAudio.Play();
                }
            }
        }
    }
    public void Rotation()
    {
        if (playManager.GameIsOn)
        {
            if (top == false)
            {
                transform.eulerAngles = new Vector3(180f, 0, 0);
            }
            else
            {
                transform.eulerAngles = Vector3.zero;
            }

            top = !top;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (playManager.GameIsOn)
        {
            if (collision.gameObject.layer.Equals(8))
            {
                curJumps = maxJumps;
                canSwitch = true;
            }
        }
    }
}
