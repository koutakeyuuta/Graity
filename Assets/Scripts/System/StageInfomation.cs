using UnityEngine;

/// <summary>
/// �e�X�e�[�W�̃N���A�󋵂��L������N���X
/// </summary>
public class StageInfomation : MonoBehaviour
{
    //�X�e�[�W��
    [HideInInspector] public const int STAGECOUNT = 3;

    //���̃X�e�[�W���N���A�������Ƃ����邩�B
    [HideInInspector] public static bool[] stageClear = new bool[STAGECOUNT];

    //���̃X�e�[�W�̃x�X�g�^�C��
    [HideInInspector] public static float[] stageBestTime = new float[STAGECOUNT];

    //���̃X�e�[�W�̊e�t���[�c���擾������ԂŁA�N���A�������Ƃ����邩�B
    [HideInInspector] public static bool[,] collectFurits = new bool[STAGECOUNT, FruitsInfomation.FRUITSCOUNT];

    /// <summary>
    /// ���̃X�e�[�W�̃N���A�󋵂��Z�[�u����
    /// </summary>
    /// <param name="stageNo">�X�e�[�W�i���o�[</param>
    /// <param name="fruits">�t���[�c�̎擾��</param>
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
    /// �X�e�[�W�̏������ׂď���������B
    /// </summary>
    public static void AllDeleteDeta()
    {
        //�X�e�[�W�̃N���A�󋵂����ׂď���������B
        for(int stageNo = 0; stageNo < stageClear.Length; stageNo++)
        {
            stageClear[stageNo] = false;
        }

        //�e�X�e�[�W�̃x�X�g�^�C�������ׂď���������B
        for(int stageNo = 0; stageNo < stageBestTime.Length; stageNo++)
        {
            stageBestTime[stageNo] = 0;
        }

        //�e�X�e�[�W�̃t���[�c�̎擾�󋵂����ׂď���������B
        for(int stageNo = 0; stageNo < collectFurits.GetLength(0); stageNo++)
        {
            for(int fruits = 0; fruits < collectFurits.GetLength(1); fruits++)
            {
                collectFurits[stageNo, fruits] = false;
            }
        }
    }
}
