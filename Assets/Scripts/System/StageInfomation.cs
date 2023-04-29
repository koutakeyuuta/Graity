using UnityEngine;

/// <summary>
/// 各ステージのクリア状況を記憶するクラス
/// </summary>
public class StageInfomation : MonoBehaviour
{
    //ステージ数
    [HideInInspector] public const int STAGECOUNT = 3;

    //そのステージをクリアしたことがあるか。
    [HideInInspector] public static bool[] stageClear = new bool[STAGECOUNT];

    //そのステージのベストタイム
    [HideInInspector] public static float[] stageBestTime = new float[STAGECOUNT];

    //そのステージの各フルーツを取得した状態で、クリアしたことがあるか。
    [HideInInspector] public static bool[,] collectFurits = new bool[STAGECOUNT, FruitsInfomation.FRUITSCOUNT];

    /// <summary>
    /// そのステージのクリア状況をセーブする
    /// </summary>
    /// <param name="stageNo">ステージナンバー</param>
    /// <param name="fruits">フルーツの取得状況</param>
    public static void StageSave(int stageNo, float bestTime, bool[] fruits)
    {
        stageClear[stageNo] = true;

        if (stageBestTime[stageNo] == 0)        stageBestTime[stageNo] = bestTime;
        if (stageBestTime[stageNo] > bestTime)  stageBestTime[stageNo] = bestTime;

        for(int fruitsNo = 0; fruitsNo < collectFurits.GetLength(1); fruitsNo++)
        {
            if (fruits[fruitsNo])
            {
                collectFurits[stageNo, fruitsNo] = fruits[fruitsNo];
            }
        }
    }

    /// <summary>
    /// ステージの情報をすべて初期化する。
    /// </summary>
    public static void AllDeleteDeta()
    {
        //ステージのクリア状況をすべて初期化する。
        for(int stageNo = 0; stageNo < stageClear.Length; stageNo++)
        {
            stageClear[stageNo] = false;
        }

        //各ステージのベストタイムをすべて初期化する。
        for(int stageNo = 0; stageNo < stageBestTime.Length; stageNo++)
        {
            stageBestTime[stageNo] = 0;
        }

        //各ステージのフルーツの取得状況をすべて初期化する。
        for(int stageNo = 0; stageNo < collectFurits.GetLength(0); stageNo++)
        {
            for(int fruits = 0; fruits < collectFurits.GetLength(1); fruits++)
            {
                collectFurits[stageNo, fruits] = false;
            }
        }
    }
}
