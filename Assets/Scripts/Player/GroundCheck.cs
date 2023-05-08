using UnityEngine;

/// <summary>
/// 接地判定を処理するクラス
/// </summary>
public class GroundCheck : MonoBehaviour
{
    [Header("地面判定のレイヤー")]
    [SerializeField] private LayerMask groundLayer;

    // 接地状態
    private bool _isGround;

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
    /// 接地判定
    /// </summary>
    private void IsGround()
    {
        _isGround = Physics2D.Linecast(transform.position,
                                       transform.position - transform.up,
                                       groundLayer);
    }
}
