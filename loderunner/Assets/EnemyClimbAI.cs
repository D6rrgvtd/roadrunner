using UnityEngine;

public class EnemyClimbAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float climbSpeed = 3f;

    private Rigidbody2D rb;
    private Transform player;

    private bool isAtLadder = false;          
    private bool isAtHorizontalLadder = false; 
    private float initialGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialGravityScale = rb.gravityScale;
      
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distanceX = player.position.x - transform.position.x;
        float distanceY = player.position.y - transform.position.y;

       
        if (isAtLadder && Mathf.Abs(distanceY) > 0.5f)
        {
            rb.gravityScale = 0f;
            
            float moveY = Mathf.Sign(distanceY) * climbSpeed;
            rb.linearVelocity = new Vector2(distanceX * 0.5f, moveY);
        }
        
        else if (isAtHorizontalLadder)
        {
            rb.gravityScale = 0f;
            
            float moveX = Mathf.Sign(distanceX) * moveSpeed;
            rb.linearVelocity = new Vector2(moveX, 0f);
        }
      
        else
        {
            rb.gravityScale = initialGravityScale;
           
            float moveX = Mathf.Sign(distanceX) * moveSpeed;
            rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) isAtLadder = true;
        if (collision.CompareTag("HorizontalLadder")) isAtHorizontalLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) isAtLadder = false;
        if (collision.CompareTag("HorizontalLadder")) isAtHorizontalLadder = false;
    }
}
