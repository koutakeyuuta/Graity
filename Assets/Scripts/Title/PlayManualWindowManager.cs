using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayManualWindowManager : MonoBehaviour
{
    [Header("マニュアル"), SerializeField] private GameObject[] Manuals;

    //現在表示されているマニュアルの番号
    private int currentManual = 0;

    /// <summary>
    /// 次のマニュアルが存在するか
    /// </summary>
    /// <returns>存在していればtrueを返す</returns>
    private bool CanNextManual()
    {
        return currentManual + 1 < Manuals.Length;
    }

    /// <summary>
    /// 次のマニュアルを表示する
    /// </summary>
    public void PushNextManualButton()
    {
        if (!CanNextManual())
        {
            CloseManualWindow();
            return;
        }

        currentManual++;
        CurrenManualActive();
    }

    /// <summary>
    /// マニュアルの表示状態を更新する
    /// </summary>
    private void CurrenManualActive()
    {
        for(int count = 0;count< Manuals.Length;count++)
        {
            if(count == currentManual) Manuals[count].SetActive(true);
            if(count != currentManual) Manuals[count].SetActive(false);
        }
    }

    /// <summary>
    /// マニュアルウィンドウを閉じる
    /// </summary>
    public void CloseManualWindow()
    {
        gameObject.SetActive(false);
        currentManual = 0;
        CurrenManualActive();
    }
}
