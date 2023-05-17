using UnityEngine;

/// <summary>
/// ワープの処理
/// </summary>
public class Warp : MonoBehaviour
{
    [Header("ワープゾーン")]
    [SerializeField] private GameObject warpZone1;
    [SerializeField] private GameObject warpZone2;

    // ワープにプレイヤーが触れたかの判定を返す
    private WarpTouchCheck _warpZone1TouchCheck;
    private WarpTouchCheck _warpZone2TouchCheck;
    
    // ワープゾーンのポジション (Pos = Position)
    private Vector2 _warpZone1Pos;
    private Vector2 _warpZone2Pos;

    private void Start()
    {
        _warpZone1TouchCheck = warpZone1.GetComponent<WarpTouchCheck>();
        _warpZone2TouchCheck = warpZone2.GetComponent<WarpTouchCheck>();

        _warpZone1Pos = warpZone1.transform.position;
        _warpZone2Pos = warpZone2.transform.position;
    }

    private void Update()
    {
        if (_warpZone1TouchCheck.IsTouchObject())
        {
            // ワープ処理
            WarpObject(_warpZone1TouchCheck.TouchObject(), _warpZone2Pos);
            // ワープに必要な情報をリセットする
            _warpZone1TouchCheck.ResetFlag();
        }

        if (_warpZone2TouchCheck.IsTouchObject())
        {
            // ワープ処理
            WarpObject(_warpZone2TouchCheck.TouchObject(), _warpZone1Pos);
            // ワープに必要な情報をリセットする
            _warpZone2TouchCheck.ResetFlag();
        }
    }

    /// <summary>
    /// ワープ処理
    /// </summary>
    /// <param name="touchObject"> ワープするオブジェクト </param>
    /// <param name="warpPos"> ワープする先の位置 </param>
    private void WarpObject(GameObject touchObject, Vector2 warpPos)
    {
        // ワープを停止する
        StopWarp();
        // オブジェクトをワープさせる
        touchObject.transform.position = warpPos;
        // 一定時間後にワープを再起動する
        Invoke(nameof(RebootWarp), 1.0f);
    }

    /// <summary>
    /// ワープを停止する
    /// </summary>
    private void StopWarp()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// ワープを再び出現させる
    /// </summary>
    private void RebootWarp()
    {
        this.gameObject.SetActive(true);
    }
}
