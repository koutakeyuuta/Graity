using UnityEngine;

/// <summary>
/// �Q�[���I���|�b�v�A�b�v�̐���
/// </summary>
public class GameExitWindow : BaseWindow
{
    /// <summary>
    /// �Q�[�����I�������郁�\�b�h
    /// </summary>
    public void Exit()
    {
        Application.Quit();
    }

    /// <summary>
    /// �Q�[���I����ʂ��J��
    /// </summary>
    public void OpneExit()
    {
        this.gameObject.SetActive(true);
    }
    
    /// <summary>
    /// �Q�[���I����ʂ����
    /// </summary>
    public void CloseGameExit()
    {
        gameObject.SetActive(false);
    }
}
