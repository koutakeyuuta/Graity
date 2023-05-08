using UnityEngine;

/// <summary>
/// �X�e�[�W�̃^�C�}�[�𐧌䂷��N���X
/// </summary>
public class StageTimer : MonoBehaviour
{
    //�N���A�^�C�����i�[����ϐ�
    private float clearTime = 30;
    //�x�X�g�^�C�����i�[����ϐ�
    private readonly float bestTime;
    //�^�C�}�[�̃I���I�t��؂�ւ���ϐ�
    private bool timerSwitch = false;
    // �ǉ����ԗ�
    private float plusTime = 5.0f;

    private void Update()
    {
        if (timerSwitch)
        {
            clearTime -= Time.deltaTime;
        }
    }

    /// <summary>
    /// �^�C�}�[�X�^�[�g
    /// </summary>
    public void TimerStart()
    {
        timerSwitch = true;
    }

    /// <summary>
    /// �^�C�}�[�X�g�b�v
    /// </summary>
    public void TimerStop()
    {
        timerSwitch = false;
    }

    /// <summary>
    /// ���݂̃^�C����Ԃ�
    /// </summary>
    /// <returns>�N���A�^�C��</returns>
    public float ClearTime()
    {
        return clearTime;
    }

    /// <summary>
    /// �x�X�g�^�C����Ԃ�
    /// </summary>
    /// <returns>�x�X�g�^�C��</returns>
    public float BestTime()
    {
        return bestTime;
    }
    
    public void AddTime()
    {
        clearTime += plusTime;
    }
}