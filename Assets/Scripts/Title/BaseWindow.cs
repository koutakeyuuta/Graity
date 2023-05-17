using UnityEngine;

/// <summary>
/// タイトルの画面の元クラス
/// </summary>
public class BaseWindow : MonoBehaviour
{
    [Header("前の画面")]
    [SerializeField] protected BaseWindow prevWindow;

    [Header("次の画面")]
    [SerializeField] protected BaseWindow[] nextWindows;

    /// <summary>
    /// 画面を開く
    /// </summary>
    public virtual void OpenWindow()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// 画面を閉じる
    /// </summary>
    public virtual void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 次の画面のいずれかがアクティブか
    /// </summary>
    /// <returns> 一つでもアクティブならtrueを返す </returns>
    protected bool IsActiveNextWindows()
    {
        // 次の画面が無ければfalseを返す
        if (nextWindows == null) { return false; }

        // 次の画面のいずれかがアクティブならtrueを返す
        foreach (BaseWindow window in nextWindows)
        {
            if (window.IsActiveThisWindow()) { return true; }
        }

        // 次の画面がすべて非アクティブならfalseを返す
        return false;
    }

    /// <summary>
    /// この画面がアクティブか
    /// </summary>
    /// <returns> アクティブならtrueを返す </returns>
    protected bool IsActiveThisWindow()
    {
        return this.gameObject.activeSelf;
    }
}
