using UnityEngine;

public class HorizontalClimb : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isLadder = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if (isLadder)
        {
            // 物理演算（重力）を完全に無視するモードに変更
            rb.bodyType = RigidbodyType2D.Kinematic;

            // Xは移動、Yは完全に固定（0）
            rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, 0f);
        }
        else
        {
            // 範囲外なら物理演算を通常(Dynamic)に戻す
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HorizontalLadder")) isLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HorizontalLadder"))
        {
            isLadder = false;
            // 抜けた瞬間にDynamicに戻さないと空中で止まってしまうので注意
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
