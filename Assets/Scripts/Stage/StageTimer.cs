using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// ステージシーンのタイム、ベストタイムに関するクラス
/// </summary>
public class StageTimer : MonoBehaviour
{
    //クリアタイムを格納する変数
    private float clearTime = 30;
    //ベストタイムを格納する変数
    private readonly float bestTime;
    //タイマーのオンオフを切り替える変数
    private bool timerSwitch = false;
    // 追加時間量
    private float plusTime = 5.0f;

    private void Update()
    {
        if (timerSwitch)
        {
            clearTime -= Time.deltaTime;
        }
    }

    /// <summary>
    /// タイマースタート
    /// </summary>
    public void TimerStart()
    {
        timerSwitch = true;
    }

    /// <summary>
    /// タイマーストップ
    /// </summary>
    public void TimerStop()
    {
        timerSwitch = false;
    }

    /// <summary>
    /// 現在のタイムを返す
    /// </summary>
    /// <returns>クリアタイム</returns>
    public float ClearTime()
    {
        return clearTime;
    }

    /// <summary>
    /// ベストタイムを返す
    /// </summary>
    /// <returns>ベストタイム</returns>
    public float BestTime()
    {
        return bestTime;
    }

    //ここから
    public void AddTime()
    {
        clearTime += plusTime;
    }
    //ここまで
}