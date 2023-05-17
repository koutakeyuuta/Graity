using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル画面のコマンドを制御
/// </summary>
public class TitleWindow : BaseWindow
{
    // 現在選択中のコマンドを格納する変数
    private int SelectCommand = 0;

    private void Update()
    {
        InputSelectCommand();

        if (IsActiveNextWindows() == false)
        {
            if (Input.GetKeyDown(KeyCode.Return)) PushCommand();
        }
    }

    /// <summary>
    /// コマンド選択を制御するメソッド
    /// </summary>
    private void InputSelectCommand()
    {
        // 上下の入力でコマンドを選択する
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) SelectCommand--;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) SelectCommand++;

        // コマンドの値を1からポップアップの数の間で制限する
        SelectCommand = Mathf.Clamp(SelectCommand, 0, nextWindows.Length);
    }

    /// <summary>
    /// 選択されたコマンドを実行する
    /// </summary>
    public void PushCommand()
    {
        if (SelectCommand == 0)
        {
            LoadStageSelectScene();
            return;
        }
        nextWindows[SelectCommand - 1].OpenWindow();
    }

    /// <summary>
    /// ステージ選択画面に遷移する
    /// </summary>
    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene(SceneName.STAGESELECT);
    }
}
