using UnityEngine;

/// <summary>
/// �v���C���[�̑���
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
        //�o���A�j���[�V�������I�������瓮����悤�ɂȂ�
        if (playStart)
        {
            //���ړ�
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

            //�c�ړ�
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
        //�S�[����������ŃA�j���[�V�������Đ�����
        if (collision.tag == "Goal")
        {
            pl_animator.SetTrigger("Goal");
        }
    }

    /// <summary>
    /// �o���A�j���[�V�����Ɋ֘A�t������Ă���
    /// </summary>
    public void Appear()
    {
        playStart = true;
        pl_rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        pl_rigidbody.velocity = new Vector2(0, -0.1f);
    }

    /// <summary>
    /// ���ŃA�j���[�V�����Ɋ֘A�t������Ă���
    /// </summary>
    public void Disapper()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// �^����ꂽ�͂𔽉f�����鏈��
    /// </summary>
    /// <param name="force"> �͂̒l </param>
    public void TakeForce(Vector2 force)
    {
        pl_rigidbody.AddForce(force);
    }
}
