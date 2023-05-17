using UnityEngine;

/// <summary>
/// ゲーム終了ポップアップの制御
/// </summary>
public class GameExitWindow : BaseWindow
{
    /// <summary>
    /// ゲームを終了させるメソッド
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// ゲーム終了画面を開く
    /// </summary>
    public void OpneExit()
    {
        this.gameObject.SetActive(true);
    }
    
    /// <summary>
    /// ゲーム終了画面を閉じる
    /// </summary>
    public void CloseGameExit()
    {
        gameObject.SetActive(false);
    }
}
