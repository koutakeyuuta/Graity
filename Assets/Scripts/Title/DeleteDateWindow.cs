using UnityEngine;

public class DeleteDateWindow : MonoBehaviour
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
    public void DeleteDate()
    {
        StageInfomation.AllDeleteDeta();
        DeleteCompletionWindow.SetActive(true);
    }
}
