using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [Header("ステージナンバー")]
    [SerializeField] private int stageNo;

    [Header("タイムUI")]
    [SerializeField] private Text timeText;
    [Header("ベストタイムUI")]
    [SerializeField] private Text bestTimeText;
    [Header("各フルーツUI")]
    [SerializeField] private GameObject[] FruitsSprite;

    [Header("フルーツマネージャー")]
    [SerializeField] private FruitsManager fruitsManager;
    [Header("ゲームタイマー")]
    [SerializeField] private GameTimer gameTimer;
    // ベストタイムの制御
    private BestTime _bestTime;

    private void Start()
    {
        _bestTime = new BestTime(stageNo);

        BestTimeUpdate();
    }

    private void Update()
    {
        FruitsUpdate();
        TimerUpdate();
    }

    /// <summary>
    /// 各フルーツのUIの更新
    /// </summary>
    private void FruitsUpdate()
    {
        for (int i = 0; i < FruitsSprite.Length; i++)
        {
            if (!fruitsManager.GetCollected()[i]) continue;

            FruitsSprite[i].SetActive(true);
        }
    }

    /// <summary>
    /// タイマーの更新
    /// </summary>
    private void TimerUpdate()
    {
        timeText.text = gameTimer.TimeLimit().ToString("F2");
    }

    /// <summary>
    /// ベストタイムの更新
    /// </summary>
    private void BestTimeUpdate()
    {
        bestTimeText.text = _bestTime.GetBestTime().ToString("F2");
    }

    /// <summary>
    /// ゲームがスタートした時の処理
    /// </summary>
    public void GameStartUI()
    {
        gameTimer.TimerStart();
    }

    /// <summary>
    /// ゲームをクリアした時の処理
    /// </summary>
    public void GameCleardUI()
    {
        gameTimer.TimerStop();
    }

    /// <summary>
    /// 時間切れかどうかを返す
    /// </summary>
    /// <returns> 時間切れかどうか </returns>
    public bool IsTimeUp()
    {
        return gameTimer.TimeLimit() < 0;
    }
}
