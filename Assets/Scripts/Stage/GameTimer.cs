using UnityEngine;

/// <summary>
/// ステージのタイマーを制御するクラス
/// </summary>
public class GameTimer : MonoBehaviour
{
    //クリアタイムを格納する変数
    private float timeLimit = 30;
    //タイマーのオンオフを切り替える変数
    private bool startSwitch = false;
    // 追加時間量
    private float plusTime = 5.0f;

    private void Update()
    {
        if (startSwitch)
        {
            timeLimit -= Time.deltaTime;
        }
    }

    /// <summary>
    /// タイマースタート
    /// </summary>
    public void TimerStart()
    {
        startSwitch = true;
    }

    /// <summary>
    /// タイマーストップ
    /// </summary>
    public void TimerStop()
    {
        startSwitch = false;
    }

    /// <summary>
    /// 現在のタイムを返す
    /// </summary>
    /// <returns>クリアタイム</returns>
    public float ClearTime()
    {
        return timeLimit;
    }
    
    /// <summary>
    /// 時間を追加する
    /// </summary>
    public void AddTime()
    {
        timeLimit += plusTime;
    }
}