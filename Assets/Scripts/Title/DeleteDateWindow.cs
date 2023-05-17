using UnityEngine;

/// <summary>
/// データ削除画面を制御するクラス
/// </summary>
public class DeleteDateWindow : BaseWindow
{
    [Header("コンフィグ画面"), SerializeField] private GameObject ConfigWindow;
    [Header("データ削除完了画面"), SerializeField] private GameObject DeleteCompletionWindow;

    /// <summary>
    /// データ削除画面を閉じる
    /// </summary>
    public void CloseDeleteDateWindow()
    {
        gameObject.SetActive(false);
        DeleteCompletionWindow.SetActive(false);
        ConfigWindow.SetActive(true);
    }

    /// <summary>
    /// データ削除完了画面を表示する
    /// </summary>
    public void CompleteDeleteDate()
    {
        StageInfomation.AllDeleteDeta();
        DeleteCompletionWindow.SetActive(true);
    }
}
