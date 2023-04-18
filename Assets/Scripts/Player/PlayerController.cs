using UnityEngine;

/// <summary>
/// プレイヤーの操作
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private BoxCollider2D groundCheck;

    private Rigidbody2D pl_rigidbody;
    private SpriteRenderer pl_spriteRenderer;
    private CapsuleCollider2D pl_collider;
    private Animator pl_animator;


    private bool playStart = false;
    private Vector2 colliderOffset;
    private Vector2 groundCheckColliderOffset;

    private void Start()
    {
        pl_rigidbody = GetComponent<Rigidbody2D>();
        pl_spriteRenderer = GetComponent<SpriteRenderer>();
        pl_collider = GetComponent<CapsuleCollider2D>();
        pl_animator = GetComponent<Animator>();

        colliderOffset = pl_collider.offset;
        groundCheckColliderOffset = groundCheck.offset;
    }

    private void FixedUpdate()
    {
        //出現アニメーションが終了したら動けるようになる
        if (playStart)
        {
            //横移動
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                pl_rigidbody.velocity = new Vector2(speed, pl_rigidbody.velocity.y);
                pl_spriteRenderer.flipX = false;
                pl_animator.SetBool("Run", true);
            }
            else if(Input.GetAxisRaw("Horizontal") < 0)
            {
                pl_rigidbody.velocity = new Vector2(-speed, pl_rigidbody.velocity.y);
                pl_spriteRenderer.flipX = true;
                pl_animator.SetBool("Run", true);
            }
            else
            {
                pl_rigidbody.velocity = new Vector2(0, pl_rigidbody.velocity.y);
                pl_animator.SetBool("Run", false);

            }

            //縦移動
            if (pl_rigidbody.gravityScale > 0)
            {
                pl_spriteRenderer.flipY = false;
                pl_collider.offset = new Vector2(colliderOffset.x, colliderOffset.y);
                groundCheck.offset = groundCheckColliderOffset;
            }
            else if(pl_rigidbody.gravityScale < 0)
            {
                pl_spriteRenderer.flipY = true;
                pl_collider.offset = new Vector2(colliderOffset.x, -colliderOffset.y);
                groundCheck.offset = -groundCheckColliderOffset;
            }
            pl_animator.SetFloat("Fall", Mathf.Abs(pl_rigidbody.velocity.y));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ゴールしたら消滅アニメーションを再生する
        if (collision.tag == "Goal")
        {
            pl_animator.SetTrigger("Goal");
        }
    }

    /// <summary>
    /// 出現アニメーションに関連付けされている
    /// </summary>
    public void Appear()
    {
        playStart = true;
        pl_rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        pl_rigidbody.velocity = new Vector2(0, -0.1f);
    }

    /// <summary>
    /// 消滅アニメーションに関連付けされている
    /// </summary>
    public void Disapper()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// 与えられた力を反映させる処理
    /// </summary>
    /// <param name="force"> 力の値 </param>
    public void TakeForce(Vector2 force)
    {
        pl_rigidbody.AddForce(force);
    }
}
