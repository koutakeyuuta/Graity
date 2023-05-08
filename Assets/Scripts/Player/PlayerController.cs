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
    [Header("出現から行動可能になるまでの時間")]
    [SerializeField] private float appearTime;
    [Header("消滅までの時間")]
    [SerializeField] private float destoryTime;

    // 接地してるか
    private bool _onGround = false;
    // 走っているか
    private bool _isRunning = false;
    // 落下しているか
    private bool _isFalling = false;
    // 消滅フラグ
    private bool _doDestroy = false;

    // コンポーネント (pl = Player)
    // 物理演算
    private Rigidbody2D _plRigidbody;
    // 画像
    private SpriteRenderer _plSpriteRenderer;
    // 当たり判定
    private CapsuleCollider2D _plCollider;
    // アニメーター
    private Animator _plAnimator;

    // スクリプト
    // プレイヤーのアニメーションを制御するクラス
    private PlayerAnimatorController _plAnimController;
    // 接地判定を処理するクラス
    private GroundCheck _plGroundCheck;

    private void Start()
    {
        _plRigidbody = GetComponent<Rigidbody2D>();
        _plSpriteRenderer = GetComponent<SpriteRenderer>();
        _plCollider = GetComponent<CapsuleCollider2D>();
        _plAnimator = GetComponent<Animator>();
        _plAnimController = GetComponent<PlayerAnimatorController>();
        _plGroundCheck = GetComponent<GroundCheck>();

        colliderOffset = _plCollider.offset;

        Invoke(nameof(Appear), appearTime);
    }

    private void FixedUpdate()
    {
        print(_plGroundCheck.GetIsGround());

        // 出現アニメーションが終了したら動けるようになる
        if (playStart)
        {
            //横移動
            MoveHorizontal();
            //縦移動
            MoveVertical();
        }

        IsGround();
        IsFalling();
        _plAnimController.AnimParamSettings(_isRunning, _isFalling, _doDestroy);
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
            _isRunning = true;

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
            _isRunning = true;
            
            return;
        }

        // 横方向の入力がない時
        // プレイヤーの横方向への力をゼロにする
        _plRigidbody.velocity = new Vector2(0, _plRigidbody.velocity.y);
        // 走るアニメーションの再生をやめる
        _isRunning = false;
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
        }
        // 重力が上向きの時
        if (_plRigidbody.gravityScale < 0)
        {
            // キャラクター画像の足を上に向けるため、反転させる
            _plSpriteRenderer.flipY = true;
            // プレイやの当たり判定を画像に合わせる
            _plCollider.offset = new Vector2(colliderOffset.x, -colliderOffset.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ゴールしたら消滅アニメーションを再生する
        if (collision.tag == "Goal")
        {
            _doDestroy = true;
            Invoke(nameof(Disapper), destoryTime);
        }
    }

    /// <summary>
    /// プレイヤーの出現を制御するメソッド
    /// </summary>
    private void Appear()
    {
        // プレイ可能にする
        playStart = true;
        // フリーズの解除
        _plRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        // フリーズの解除後、すこし力を加えないと落ちてくれないので力を加える
        _plRigidbody.AddForce(new Vector2(0, -0.1f));
    }

    /// <summary>
    /// プレイヤーを消滅させるメソッド
    /// </summary>
    private void Disapper()
    {
        Destroy(gameObject);
    }

    private void IsFalling()
    {
        _isFalling = Mathf.Abs(_plRigidbody.velocity.y) > 0.0f;
    }

    private void IsGround()
    {
        _onGround = _plGroundCheck.GetIsGround();
    }
}
