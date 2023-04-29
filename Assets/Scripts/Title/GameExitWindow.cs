using UnityEngine;

/// <summary>
/// ゲーム終了ポップアップの制御
/// </summary>
public class GameExitWindow : MonoBehaviour
{
    /// <summary>
    /// ゲームを終了させるメソッド
    /// </summary>
    public void GameExit()
    {
        Application.Quit();
    }
    
    /// <summary>
    /// ゲーム終了ポップアップを閉じる
    /// </summary>
    public void CloseGameExitWindow()
    {
        gameObject.SetActive(false);
    }
}
