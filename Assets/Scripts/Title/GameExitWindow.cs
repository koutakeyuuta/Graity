using UnityEngine;

/// <summary>
/// �Q�[���I���|�b�v�A�b�v�̐���
/// </summary>
public class GameExitWindow : MonoBehaviour
{
    /// <summary>
    /// �Q�[�����I�������郁�\�b�h
    /// </summary>
    public void GameExit()
    {
        Application.Quit();
    }
    
    /// <summary>
    /// �Q�[���I���|�b�v�A�b�v�����
    /// </summary>
    public void CloseGameExitWindow()
    {
        gameObject.SetActive(false);
    }
}
