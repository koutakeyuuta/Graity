using UnityEngine;

/// <summary>
/// �X�e�[�W�̃^�C�}�[�𐧌䂷��N���X
/// </summary>
public class GameTimer : MonoBehaviour
{
    //�N���A�^�C�����i�[����ϐ�
    private float timeLimit = 30;
    //�^�C�}�[�̃I���I�t��؂�ւ���ϐ�
    private bool startSwitch = false;
    // �ǉ����ԗ�
    private float plusTime = 5.0f;

    private void Update()
    {
        if (startSwitch)
        {
            timeLimit -= Time.deltaTime;
        }
    }

    /// <summary>
    /// �^�C�}�[�X�^�[�g
    /// </summary>
    public void TimerStart()
    {
        startSwitch = true;
    }

    /// <summary>
    /// �^�C�}�[�X�g�b�v
    /// </summary>
    public void TimerStop()
    {
        startSwitch = false;
    }

    /// <summary>
    /// ���݂̃^�C����Ԃ�
    /// </summary>
    /// <returns>�N���A�^�C��</returns>
    public float ClearTime()
    {
        return timeLimit;
    }
    
    /// <summary>
    /// ���Ԃ�ǉ�����
    /// </summary>
    public void AddTime()
    {
        timeLimit += plusTime;
    }
}