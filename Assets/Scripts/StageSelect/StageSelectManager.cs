//ステージセレクトマネージャー
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Editor;

public class StageSelectManager : MonoBehaviour
{
    private int selectStageNo = 0;
    private const int STAGENOMIN = 0;
    private const int STAGENOMAX = 2;

    [SerializeField] private Text StageNo_Text;
    [SerializeField] private Text StageName_Text;
    [SerializeField] private string[] stageNames;
    [SerializeField] private GameObject LeftArrow_Object;
    [SerializeField] private GameObject RightArrow_Object;

    [SerializeField] private SpriteRenderer Apple_sr;
    [SerializeField] private SpriteRenderer Banana_sr;
    [SerializeField] private SpriteRenderer Cherry_sr;
    [SerializeField] private Text BestTime_Text;

    [SerializeField] private Transform Previews_transform;
    private void Start()
    {
        StageInfoUpdate();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        PushLeftArrowButton();
    //    }

    //    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        PushRightArrowButton();
    //    }

    //    if (Input.GetKeyDown(KeyCode.Return))
    //    {
    //        PushStartButton();
    //    }
    //}

    /// <summary>
    /// 左矢印を押すとステージを切り替える
    /// </summary>
    public void PushLeftArrowButton()
    {
        if(selectStageNo > STAGENOMIN)
        {
            selectStageNo -= 1;
            StageInfoUpdate();
        }
    }
    /// <summary>
    /// 右矢印を押すとステージを切り替える
    /// </summary>
    public void PushRightArrowButton()
    {
        if(selectStageNo < STAGENOMAX)
        {
            selectStageNo += 1;
            StageInfoUpdate();
        }
    }

    /// <summary>
    /// UIの情報を更新する
    /// </summary>
    private void StageInfoUpdate()
    {
        //ステージ番号
        StageNo_Text.text = "Stage " + (selectStageNo + 1);

        //ステージ名
        StageName_Text.text = "～" + stageNames[selectStageNo] + "～";

        //セレクト矢印が端まで行ったら非アクティブにする。
        if(selectStageNo == STAGENOMIN)
        {
            LeftArrow_Object.SetActive(false);
        }
        else
        {
            LeftArrow_Object.SetActive(true);
        }
        if(selectStageNo == STAGENOMAX)
        {
            RightArrow_Object.SetActive(false);
        }
        else
        {
            RightArrow_Object.SetActive(true);
        }

        //フルーツ取得状況
        //ステージ情報クラスの各ステージのフルーツ収集状況がtrueならUIを濃く表示する。
        if(StageInfomation.collectFurits[selectStageNo, FruitsInfomation.APPLE])
        {
            Apple_sr.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Apple_sr.color = new Color(1, 1, 1, 0.1f);

        }

        if (StageInfomation.collectFurits[selectStageNo, FruitsInfomation.BANANA])
        {
            Banana_sr.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Banana_sr.color = new Color(1, 1, 1, 0.1f);

        }
        if (StageInfomation.collectFurits[selectStageNo, FruitsInfomation.CHERRY])
        {
            Cherry_sr.color = new Color(1, 1, 1, 1);
        }
        else
        {
            Cherry_sr.color = new Color(1, 1, 1, 0.1f);
        }

        //各ステージのベストタイムをステージ情報クラスから取得し、テキストで表示
        BestTime_Text.text = "BestTime " + StageInfomation.stageBestTime[selectStageNo].ToString("F2");

        //プレビュー画像を指定された方向にずらす。
        Previews_transform.position = new Vector2((selectStageNo) * (-20), 0);
    }

    /// <summary>
    /// ゲームをスタートする
    /// </summary>
    public void PushStartButton()
    {
        SceneManager.LoadScene("Stage" + selectStageNo);
    }

    /// <summary>
    /// Titleに戻る
    /// </summary>
    public void PushTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
