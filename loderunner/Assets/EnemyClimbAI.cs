using UnityEngine;

public class EnemyClimbAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float climbSpeed = 3f;

    private Rigidbody2D rb;
    private Transform player;

    private bool isAtLadder = false;           // 梯子エリアか
    private bool isAtHorizontalLadder = false; // うんていエリアか
    private float initialGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialGravityScale = rb.gravityScale;
        // "Player"タグを持つオブジェクトを自動で探す
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distanceX = player.position.x - transform.position.x;
        float distanceY = player.position.y - transform.position.y;

        // --- 1. 梯子（上下移動）のAI ---
        if (isAtLadder && Mathf.Abs(distanceY) > 0.5f)
        {
            rb.gravityScale = 0f;
            // プレイヤーの高さに合わせて上下移動、X軸は少し寄せる
            float moveY = Mathf.Sign(distanceY) * climbSpeed;
            rb.linearVelocity = new Vector2(distanceX * 0.5f, moveY);
        }
        // --- 2. うんてい（左右移動）のAI ---
        else if (isAtHorizontalLadder)
        {
            rb.gravityScale = 0f;
            // X軸を優先して移動、Y軸は固定
            float moveX = Mathf.Sign(distanceX) * moveSpeed;
            rb.linearVelocity = new Vector2(moveX, 0f);
        }
        // --- 3. 通常の移動（地上） ---
        else
        {
            rb.gravityScale = initialGravityScale;
            // 地上では左右のみ追跡
            float moveX = Mathf.Sign(distanceX) * moveSpeed;
            rb.linearVelocity = new Vector2(moveX, rb.linearVelocity.y);
        }
    }

    // エリア判定
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
