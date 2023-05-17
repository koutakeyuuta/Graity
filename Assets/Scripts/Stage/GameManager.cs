using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ステージシーン(ゲームシーン)を制御するクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("ステージナンバー")] 
    [SerializeField] private int stageNo;

    [Header("ゲームUIコントローラー")]
    [SerializeField] private GameUIController gameUIController;

    [SerializeField] private GameObject stageClearUI_Object;
    [Header("ゴールコントローラー")]
    [SerializeField] private GoalController goalController;

    // ゴール後の処理を一回だけ実行するためだけの変数(良くない)
    private bool _goalMethodStop = true;

    private void Update()
    {
        // 操作が入力されるとタイマースタート
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) 
                      || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && _goalMethodStop)
        {
            gameUIController.GameStartUI();
        }

        // 時間切れでリスタート
        if (gameUIController.IsTimeUp()) RestartStage();

        // ゴールしたときの処理
        if (goalController.IsGoal()　&& _goalMethodStop) StageClear();
    }

    /// <summary>
    /// ステージをクリアした際の処理
    /// </summary>
    private void StageClear()
    {
        // ステージクリア後の処理を一回だけ実行するため(良くない)
        _goalMethodStop = false;

        // ステージ状況を保存。
        //StageInfomation.StageSave(stageNo, _gameTimer.ClearTime(), _collectedFruits);

        // ステージクリア後のUIを表示する。
        stageClearUI_Object.SetActive(true);
    }

    /// <summary>
    /// ステージをリロード(リスタート)する。
    /// ステージナンバー「999」はステージベースシーンを指す。
    /// </summary>
    public void RestartStage()
    {
        if(stageNo == 999)
        {
            SceneManager.LoadScene("StageBase");
            return;
        }
        SceneManager.LoadScene(SceneName.STAGE + stageNo);
    }

    /// <summary>
    /// ステージセレクトシーンに遷移する。
    /// </summary>
    public void TransitionStageSelectScene()
    {
        SceneManager.LoadScene(SceneName.STAGESELECT);
    }

    /// <summary>
    /// 次のステージへ遷移する。
    /// 最後のステージではステージセレクトシーンに遷移する。
    /// ステージベースシーンでもステージセレクトシーンに遷移する。
    /// </summary>
    public void TransitionNextStage()
    {
        if ((stageNo + 1) >= StageInfomation.STAGECOUNT) TransitionStageSelectScene();
        else SceneManager.LoadScene(SceneName.STAGE + (stageNo + 1));
    }
}
