/// <summary>
/// �Q�[�����̃x�X�g�^�C�����Ǘ�����N���X
/// </summary>
public class BestTime
{
    // �X�e�[�W�i���o�[
    private int _stageNo;
    // �ߋ��̃x�X�g�^�C��
    private float _bestTime;

    // �R���X�g���N�^
    public BestTime(int stageNo)
    {
        _stageNo = stageNo;
        _bestTime = StageInfomation.stageBestTime[_stageNo];
    }

    /// <summary>
    /// �ߋ��̃x�X�g�^�C����Ԃ�
    /// </summary>
    /// <returns> �ߋ��̃x�X�g�^�C�� </returns>
    public float GetBestTime()
    {
        return _bestTime;
    }

    /// <summary>
    /// �x�X�g�^�C�����X�V����
    /// </summary>
    /// <param name="time"> ���݂̃N���A�^�C�� </param>
    public void UpdateBestTime(float clearTime)
    {
        // �ߋ��̃x�X�g�^�C����茻�݂̃N���A�^�C���̂ق���������΍X�V����
        if (clearTime < _bestTime) StageInfomation.stageBestTime[_stageNo] = clearTime;
    }
}
