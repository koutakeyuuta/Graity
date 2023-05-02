using UnityEngine;

/// <summary>
/// プレイヤーに外部から力を加えるクラス
/// </summary>
public class PlayerGetForce : MonoBehaviour
{
    // pl = player
    // プレイヤーのRigidbody2D
    private Rigidbody2D _plRb;

    private void Start()
    {
        // コンポーネントの取得
        _plRb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 受け取った力をプレイヤーに加えるメソッド
    /// </summary>
    /// <param name="force"></param>
    public void GetForce(Vector2 force)
    {
        _plRb.AddForce(force);
    }
}
