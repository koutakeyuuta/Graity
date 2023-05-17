using UnityEngine;

public class WarpTouchCheck : MonoBehaviour
{
    // ワープの当たり判定
    private CircleCollider2D _warpZone;
    // 接触したオブジェクトを格納する
    private GameObject _touchGameObject;

    // オブジェクトが接触しているかどうか
    private bool _isTouchObject = false;

    private void Start()
    {
        _warpZone = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isTouchObject = true;
            _touchGameObject = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isTouchObject = true;
            _touchGameObject = collision.gameObject;
        } 
    }

    /// <summary>
    /// ワープにオブジェクトが接触しているかを返す
    /// </summary>
    /// <returns> オブジェクトが接触しているか </returns>
    public bool IsTouchObject()
    {
        return _isTouchObject;
    }

    /// <summary>
    /// 接触しているオブジェクトを返す
    /// </summary>
    /// <returns> 接触しているオブジェクト </returns>
    public GameObject TouchObject()
    {
        return _touchGameObject;
    }

    /// <summary>
    /// ワープに必要な情報をリセットする
    /// </summary>
    public void ResetFlag()
    {
        _isTouchObject = false;
        _touchGameObject = null;
    }
}