using UnityEngine;

/// <summary>
/// オーディオ情報を管理するクラス
/// 今はスタティック変数で保存しているが
/// いずれは別の記憶方法を採用したい
/// </summary>
public class BGMInfomation : MonoBehaviour
{
    // 全体ボリュームを記憶する変数
    private static float VolumeParameter = 0.5f;

    /// <summary>
    /// 受け取った値を記憶するためのメソッド
    /// </summary>
    /// <param name="changedValue"> 入力された変更後のボリュームの値 </param>
    /// <exception cref="System.Exception"> 入力された値が範囲外の時に処理される </exception>
    public static void VolumeSetting(float changedValue)
    {
        // エラー処理
        if(changedValue < 0) throw new System.Exception("正しい値を設定してください");
        if(changedValue > 1) throw new System.Exception("正しい値を設定してください");

        // 値の格納
        VolumeParameter = changedValue;
    }

    /// <summary>
    /// 現在の全体ボリュームの値を返すメソッド
    /// </summary>
    /// <returns> 現在の全体ボリューム </returns>
    public static float VolumeCheck()
    {
        // 全体ボリュームを返す
        return VolumeParameter;
    }
}