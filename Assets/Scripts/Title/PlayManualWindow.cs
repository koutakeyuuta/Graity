using UnityEngine;

/// <summary>
/// 遊び方画面を表示し、スライドを管理するクラス
/// </summary>
public class PlayManualWindow : BaseWindow
{
    [Header("遊び方のスライド")]
    [SerializeField] private GameObject[] Manuals;

    //現在表示されているスライドの番号
    private int currentManual = 0;

    private void Update()
    {
        // エンターキーで次のスライドへ
        if (Input.GetKeyDown(KeyCode.Return)) { PushNextManualButton(); }
        // エスケープキーで画面を閉じる
        if (Input.GetKeyDown(KeyCode.Escape)) { CloseWindow(); }
    }

    /// <summary>
    /// 次のスライドが存在するか
    /// </summary>
    /// <returns>存在していればtrueを返す</returns>
    private bool CanNextManual()
    {
        return currentManual + 1 < Manuals.Length;
    }

    /// <summary>
    /// 次のスライドを表示する
    /// </summary>
    public void PushNextManualButton()
    {
        if (!CanNextManual())
        {
            CloseWindow();
            return;
        }

        currentManual++;
        CurrenManualActive();
    }

    /// <summary>
    /// スライドの表示状態を更新する
    /// </summary>
    private void CurrenManualActive()
    {
        for(int count = 0;count< Manuals.Length;count++)
        {
            if(count == currentManual) Manuals[count].SetActive(true);
            if(count != currentManual) Manuals[count].SetActive(false);
        }
    }

    /// <summary>
    /// 遊び方画面を閉じる
    /// </summary>
    public override void CloseWindow()
    {
        base.CloseWindow();
        currentManual = 0;
        CurrenManualActive();
    }
}
