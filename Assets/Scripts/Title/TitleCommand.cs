using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル画面のコマンドを制御するクラス
/// </summary>
public class TitleCommand : MonoBehaviour
{
    [Header("マニュアル画面"), SerializeField] private GameObject PlayManualWindow;
    [Header("コンフィグ画面"), SerializeField] private GameObject ConfigWindow;
    [Header("ゲーム終了画面"), SerializeField] private GameObject GameExitWindow;

    // 現在選択中のコマンドを格納する変数
    private int SelectCommand = 0;

    private void Update()
    {
        InputSelectCommand();

        if (Input.GetKeyDown(KeyCode.Return)) PushCommand();
    }

    /// <summary>
    /// コマンド選択を制御するメソッド
    /// ** マジックナンバーあり、修正せよ **
    /// </summary>
    private void InputSelectCommand()
    {
        // 上下の入力でコマンドを選択する
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) SelectCommand--;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) SelectCommand++;

        // コマンドの値をクランプする
        SelectCommand = Mathf.Clamp(SelectCommand, 0, 3);
    }

    /// <summary>
    /// 選択中のコマンドに合わせた処理を行う
    /// ** マジックナンバーあり、修正せよ **
    /// </summary>
    private void PushCommand()
    {
        if (SelectCommand == 0) PushStageSelect();
        if (SelectCommand == 1) PushPlayManual();
        if (SelectCommand == 2) PushConfig();
        if (SelectCommand == 3) PushGameExit();
    }

    /// <summary>
    /// ステージセレクト画面に遷移するメソッド
    /// </summary>
    public void PushStageSelect()
    {
        SceneManager.LoadScene(SceneName.STAGESELECT);
    }

    /// <summary>
    /// マニュアル画面を表示するメソッド
    /// </summary>
    public void PushPlayManual()
    {
        PlayManualWindow.SetActive(true);
    }

    /// <summary>
    /// 設定画面を表示するメソッド
    /// </summary>
    public void PushConfig()
    {
        ConfigWindow.SetActive(true);
    }

    /// <summary>
    /// 終了画面を表示するメソッド
    /// </summary>
    public void PushGameExit()
    {
        GameExitWindow.SetActive(true);
    }
}
