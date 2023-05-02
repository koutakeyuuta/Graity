using UnityEngine;

/// <summary>
/// 接地判定を処理するクラス
/// </summary>
public class GroundCheck : MonoBehaviour
{
    // 接地状態
    private bool onGround;

    /// <summary>
    /// 接地状態を返す
    /// </summary>
    /// <returns> 接地状態 </returns>
    public bool IsGround()
    {
        return onGround;
    }

    // 接地判定
    private void OnTriggerEnter2D(Collider2D collision)
    {
            onGround = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
            onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            onGround = false;
    }
}
