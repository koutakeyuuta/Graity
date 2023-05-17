/// <summary>
/// ゲーム中のベストタイムを管理するクラス
/// </summary>
public class BestTime
{
    // ステージナンバー
    private int _stageNo;
    // 過去のベストタイム
    private float _bestTime;

    // コンストラクタ
    public BestTime(int stageNo)
    {
        _stageNo = stageNo;
        _bestTime = StageInfomation.stageBestTime[_stageNo];
    }

    /// <summary>
    /// 過去のベストタイムを返す
    /// </summary>
    /// <returns> 過去のベストタイム </returns>
    public float GetBestTime()
    {
        return _bestTime;
    }

    /// <summary>
    /// ベストタイムを更新する
    /// </summary>
    /// <param name="time"> 現在のクリアタイム </param>
    public void UpdateBestTime(float clearTime)
    {
        // 過去のベストタイムより現在のクリアタイムのほうが早ければ更新する
        if (clearTime < _bestTime) StageInfomation.stageBestTime[_stageNo] = clearTime;
    }
}
