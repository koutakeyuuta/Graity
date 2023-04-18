using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージシーンのUIを制御するクラス
/// </summary>
public class StageUIController : MonoBehaviour
{
    [Header("フルーツUI")]
    [SerializeField] private SpriteRenderer[] FruitsUI_spriteRenderer;

    [Header("タイムUI")]
    [SerializeField] private Text time_text;

    [Header("ベストタイムUI")]
    [SerializeField] private Text bestTime_text;

    //ここから
    [SerializeField] private GameObject PlusTimePrefab;

    private GameObject timePlus;
    //ここまで

    /// <summary>
    /// フルーツを取得したことを示すUIを表示する。
    /// </summary>
    /// <param name="fruitsNo">フルーツのナンバー</param>
    public void FruitsUIDisplay(int fruitsNo)
    {
        FruitsUI_spriteRenderer[fruitsNo].color = new Color(1, 1, 1, 1);
    }

    /// <summary>
    /// タイムUIを更新する。
    /// </summary>
    /// <param name="time">現在のタイム</param>
    public void TimeUIUpdate(float time)
    {
        time_text.text = "Time " + time.ToString("F2");
    }

    /// <summary>
    /// ベストタイムUIを更新する。
    /// </summary>
    /// <param name="bestTime">ベストタイム</param>
    public void BestTimeUIDisplay(float bestTime)
    {
        bestTime_text.text = "(BestTime " + bestTime.ToString("F2") + ")";
    }

    //ここから
    public void TimePlusAnimation()
    {
        GameObject TimePlus = Instantiate(PlusTimePrefab, transform.position, Quaternion.identity);
        timePlus = TimePlus;
        Invoke(nameof(AnimationDestroy), 1.0f);
    }

    private void AnimationDestroy()
    {
        Destroy(timePlus);

        return;
    }
    //ここまで
}
