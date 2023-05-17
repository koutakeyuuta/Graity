using UnityEngine;

/// <summary>
/// �f�[�^�폜��ʂ𐧌䂷��N���X
/// </summary>
public class DeleteDateWindow : BaseWindow
{
    [Header("�R���t�B�O���"), SerializeField] private GameObject ConfigWindow;
    [Header("�f�[�^�폜�������"), SerializeField] private GameObject DeleteCompletionWindow;

    /// <summary>
    /// �f�[�^�폜��ʂ����
    /// </summary>
    public void CloseDeleteDateWindow()
    {
        gameObject.SetActive(false);
        DeleteCompletionWindow.SetActive(false);
        ConfigWindow.SetActive(true);
    }

    /// <summary>
    /// �f�[�^�폜������ʂ�\������
    /// </summary>
    public void CompleteDeleteDate()
    {
        StageInfomation.AllDeleteDeta();
        DeleteCompletionWindow.SetActive(true);
    }
}
