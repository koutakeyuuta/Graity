using UnityEngine;

/// <summary>
/// 接地判定を処理するクラス
/// </summary>
public class GroundCheck : MonoBehaviour
{
    [Header("地面判定のレイヤー")]
    [SerializeField] private LayerMask groundLayer;
    [Header("接地判定")]
    [SerializeField] private BoxCollider2D groundCheckCollider;

    // 接地判定のY軸のオフセット
    private float _groundCheckColliderOffset;
    // 接地状態
    private bool _isGround;

    private void Start()
    {
        _groundCheckColliderOffset = groundCheckCollider.offset.y;
    }

    /// <summary>
    /// 接地状態を返す
    /// </summary>
    /// <returns> 接地状態 </returns>
    public bool GetIsGround()
    {
        IsGround();
        return _isGround;
    }

    /// <summary>
    /// 接地判定を反転させる
    /// trueで通常(下向き),falseで反転(上向き)
    /// </summary>
    public void ReverseColliderOffset(bool gravity)
    {
        if (gravity)
        {
            groundCheckCollider.offset = new Vector2(groundCheckCollider.offset.x, _groundCheckColliderOffset);
            return;
        }

        if (!gravity)
        {
            groundCheckCollider.offset = new Vector2(groundCheckCollider.offset.x, -_groundCheckColliderOffset);
            return;
        }
    }

    /// <summary>
    /// 接地判定
    /// </summary>
    private void IsGround()
    {
        _isGround = groundCheckCollider.IsTouchingLayers(groundLayer);
    }
}
