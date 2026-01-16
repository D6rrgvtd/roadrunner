using UnityEngine;

public class gimmickmain : MonoBehaviour
{
    [SerializeField] private float climbSpeed = 5f;
    private Rigidbody2D rb;
    private float verticalInput;
    private bool isLadder = false;
    private bool isClimbing = false;
    private float initialGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialGravityScale = rb.gravityScale;
    }

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");

       
        if (isLadder && Mathf.Abs(verticalInput) > 0.1f)
        {
            isClimbing = true;
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * climbSpeed);
        }
        else
        {
            rb.gravityScale = initialGravityScale;
        }
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) isLadder = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) isLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}

