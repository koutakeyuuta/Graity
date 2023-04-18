//�X�e�[�W�Z���N�g�}�l�[�W���[
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
    /// �����������ƃX�e�[�W��؂�ւ���
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
    /// �E���������ƃX�e�[�W��؂�ւ���
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
    /// UI�̏����X�V����
    /// </summary>
    private void StageInfoUpdate()
    {
        //�X�e�[�W�ԍ�
        StageNo_Text.text = "Stage " + (selectStageNo + 1);

        //�X�e�[�W��
        StageName_Text.text = "�`" + stageNames[selectStageNo] + "�`";

        //�Z���N�g��󂪒[�܂ōs�������A�N�e�B�u�ɂ���B
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

        //�t���[�c�擾��
        //�X�e�[�W���N���X�̊e�X�e�[�W�̃t���[�c���W�󋵂�true�Ȃ�UI��Z���\������B
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

        //�e�X�e�[�W�̃x�X�g�^�C�����X�e�[�W���N���X����擾���A�e�L�X�g�ŕ\��
        BestTime_Text.text = "BestTime " + StageInfomation.stageBestTime[selectStageNo].ToString("F2");

        //�v���r���[�摜���w�肳�ꂽ�����ɂ��炷�B
        Previews_transform.position = new Vector2((selectStageNo) * (-20), 0);
    }

    /// <summary>
    /// �Q�[�����X�^�[�g����
    /// </summary>
    public void PushStartButton()
    {
        SceneManager.LoadScene("Stage" + selectStageNo);
    }

    /// <summary>
    /// Title�ɖ߂�
    /// </summary>
    public void PushTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
