using UnityEngine;

/// <summary>
/// �^�C�g���̉�ʂ̌��N���X
/// </summary>
public class BaseWindow : MonoBehaviour
{
    [Header("�O�̉��")]
    [SerializeField] protected BaseWindow prevWindow;

    [Header("���̉��")]
    [SerializeField] protected BaseWindow[] nextWindows;

    /// <summary>
    /// ��ʂ��J��
    /// </summary>
    public virtual void OpenWindow()
    {
        this.gameObject.SetActive(true);
    }

    /// <summary>
    /// ��ʂ����
    /// </summary>
    public virtual void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// ���̉�ʂ̂����ꂩ���A�N�e�B�u��
    /// </summary>
    /// <returns> ��ł��A�N�e�B�u�Ȃ�true��Ԃ� </returns>
    protected bool IsActiveNextWindows()
    {
        // ���̉�ʂ��������false��Ԃ�
        if (nextWindows == null) { return false; }

        // ���̉�ʂ̂����ꂩ���A�N�e�B�u�Ȃ�true��Ԃ�
        foreach (BaseWindow window in nextWindows)
        {
            if (window.IsActiveThisWindow()) { return true; }
        }

        // ���̉�ʂ����ׂĔ�A�N�e�B�u�Ȃ�false��Ԃ�
        return false;
    }

    /// <summary>
    /// ���̉�ʂ��A�N�e�B�u��
    /// </summary>
    /// <returns> �A�N�e�B�u�Ȃ�true��Ԃ� </returns>
    protected bool IsActiveThisWindow()
    {
        return this.gameObject.activeSelf;
    }
}
