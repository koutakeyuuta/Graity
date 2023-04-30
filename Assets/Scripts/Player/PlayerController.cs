using UnityEngine;

/// <summary>
/// プレイヤーの操作
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("速さ")]
    [SerializeField] private float speed;
    [Header("行動可能")]
    [SerializeField] private bool playStart = false;
    [Header("当たり判定のオフセット")]
    [SerializeField] private Vector2 colliderOffset;
    [Header("接地判定のオフセット")]
    [SerializeField] private Vector2 groundCheckColliderOffset;
    [Header("接地判定")]
    [SerializeField] private BoxCollider2D groundCheck;
    [Header("消滅までの時間")]
    [SerializeField] private float destoryTime;

    // コンポーネント (pl = Player)
    // 物理演算
    private Rigidbody2D _plRigidbody;
    // 画像
    private SpriteRenderer _plSpriteRenderer;
    // 当たり判定
    private CapsuleCollider2D _plCollider;
    // アニメーター
    private Animator _plAnimator;

    private void Start()
    {
        _plRigidbody = GetComponent<Rigidbody2D>();
        _plSpriteRenderer = GetComponent<SpriteRenderer>();
        _plCollider = GetComponent<CapsuleCollider2D>();
        _plAnimator = GetComponent<Animator>();

        colliderOffset = _plCollider.offset;
        groundCheckColliderOffset = groundCheck.offset;
    }

    private void FixedUpdate()
    {
        // 出現アニメーションが終了したら動けるようになる
        if (playStart)
        {
            //横移動
            MoveHorizontal();
            //縦移動
            MoveVertical();

            // アニメーターの落ちるパラメーターをセットする
            _plAnimator.SetFloat("Fall", Mathf.Abs(_plRigidbody.velocity.y));
        }
    }

    /// <summary>
    /// 横の移動を制御するメソッド
    /// </summary>
    private void MoveHorizontal()
    {
        // 右方向に入力された時
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            // プレイヤーを右方向に動かす
            _plRigidbody.velocity = new Vector2(speed, _plRigidbody.velocity.y);
            // キャラクター画像を右に向けるため、反転をオフにする
            _plSpriteRenderer.flipX = false;
            // 走るアニメーションを再生させる
            _plAnimator.SetBool("Run", true);

            return;
        }
        // 左方向に入力された時
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            // プレイヤーを左方向に動かす
            _plRigidbody.velocity = new Vector2(-speed, _plRigidbody.velocity.y);
            // キャラクター画像を左に向けるため、反転させる
            _plSpriteRenderer.flipX = true;
            // 走るアニメーションを再生させる
            _plAnimator.SetBool("Run", true);
            
            return;
        }

        // 横方向の入力がない時
        // プレイヤーの横方向への力をゼロにする
        _plRigidbody.velocity = new Vector2(0, _plRigidbody.velocity.y);
        // 走るアニメーションの再生をやめる
        _plAnimator.SetBool("Run", false);
    }


    private void MoveVertical()
    {
        // 重力が下向きの時
        if (_plRigidbody.gravityScale >= 0)
        {
            // キャラクター画像の足を下に向けるため、反転をオフにする
            _plSpriteRenderer.flipY = false;
            // プレイヤーの当たり判定を画像に合わせる
            _plCollider.offset = new Vector2(colliderOffset.x, colliderOffset.y);
            // 接地判定用当たり判定を下にする
            groundCheck.offset = groundCheckColliderOffset;
        }
        // 重力が上向きの時
        if (_plRigidbody.gravityScale < 0)
        {
            // キャラクター画像の足を上に向けるため、反転させる
            _plSpriteRenderer.flipY = true;
            // プレイやの当たり判定を画像に合わせる
            _plCollider.offset = new Vector2(colliderOffset.x, -colliderOffset.y);
            // 接地判定用当たり判定を上にする
            groundCheck.offset = -groundCheckColliderOffset;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ゴールしたら消滅アニメーションを再生する
        if (collision.tag == "Goal")
        {
            _plAnimator.SetTrigger("Goal");
            Invoke(nameof(Disapper), destoryTime);
        }
    }

    /// <summary>
    /// プレイヤーの出現を制御するメソッド
    /// </summary>
    public void Appear()
    {
        // プレイ可能にする
        playStart = true;
        // フリーズの解除
        _plRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        // フリーズの解除後、すこし力を加えないと落ちてくれないので力を加える
        _plRigidbody.velocity = new Vector2(0, -0.1f);
    }

    /// <summary>
    /// プレイヤーを消滅させるメソッド
    /// </summary>
    private void Disapper()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// 受け取った力をプレイヤーに加えるメソッド
    /// </summary>
    /// <param name="force"> 力の値 </param>
    public void TakeForce(Vector2 force)
    {
        _plRigidbody.AddForce(force);
    }
}
