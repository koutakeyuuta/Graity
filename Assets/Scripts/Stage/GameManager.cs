using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ステージシーン(ゲームシーン)を制御するクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("ステージナンバー")] 
    [SerializeField] private int stageNo;

    [Header("ステージUIコントローラー")]
    [SerializeField] private StageUIController stageUIController;

    [Header("ステージクリアUI")]
    [SerializeField] private GameObject stageClearUI_Object;

    [Header("ゴールコントローラー")]
    [SerializeField] private GoalController goalController;

    [Header("フルーツオブジェクト")]
    [SerializeField] private GameObject[] Fruits_Object;

    private GameTimer _gameTimer;

    // フルーツを取得しているかどうか。
    private bool[] _collectedFruits = new bool[FruitsInfomation.FRUITSCOUNT];

    // ゴール後の処理を一回だけ実行するためだけの変数(良くない)
    private bool _goalMethodStop = true;

    private void Start()
    {
        // フルーツの取得状況を初期化
        FruitsCollectDelete();
        // ステージのベストタイムUIを更新
        stageUIController.BestTimeUIDisplay(StageInfomation.stageBestTime[stageNo]);
    }

    private void Update()
    {
        // 操作が入力されるとタイマースタート
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) 
                      || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && _goalMethodStop)
        {
            _gameTimer.TimerStart();
        }

        // 時間切れでリスタート
        if (_gameTimer.ClearTime() <= 0) RestartStage();

        // 各フルーツが消滅したこと(取得された)を判定する。
        for(int count = 0; count < Fruits_Object.Length; count++) 
        {
            // フルーツが消滅 and フルーツが取得されていれば(同じ処理を繰り返さないようにしている)
            if(Fruits_Object[count] == null && !_collectedFruits[count])
            {
                // フルーツUIを更新する。
                stageUIController.FruitsUIDisplay(count);
                // フルーツを取得したことを記憶する。
                _collectedFruits[count] = true;

                // 制限時間追加
                _gameTimer.AddTime();
                // 時間追加アニメーション
                stageUIController.TimePlusAnimation();
            }
        }

        // ゴールしたときの処理
        if (goalController.IsGoal()　&& _goalMethodStop) StageClear();

        // ステージのクリアタイムUIを更新する
        stageUIController.TimeUIUpdate(_gameTimer.ClearTime());
    }

    /// <summary>
    /// フルーツの取得状況を初期化する。
    /// </summary>
    private void FruitsCollectDelete()
    {
        for(int fruitsNo = 0; fruitsNo < _collectedFruits.Length; fruitsNo++)
        {
            _collectedFruits[fruitsNo] = false;
        }
    }

    /// <summary>
    /// ステージをクリアした際の処理
    /// </summary>
    private void StageClear()
    {
        // ステージクリア後の処理を一回だけ実行するため(良くない)
        _goalMethodStop = false;

        // タイマーストップ。
        _gameTimer.TimerStop();

        // ステージ状況を保存。
        StageInfomation.StageSave(stageNo, _gameTimer.ClearTime(), _collectedFruits);

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
