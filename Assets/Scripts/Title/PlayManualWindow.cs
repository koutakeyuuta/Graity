using UnityEngine;

/// <summary>
/// �V�ѕ���ʂ�\�����A�X���C�h���Ǘ�����N���X
/// </summary>
public class PlayManualWindow : BaseWindow
{
    [Header("�V�ѕ��̃X���C�h")]
    [SerializeField] private GameObject[] Manuals;

    //���ݕ\������Ă���X���C�h�̔ԍ�
    private int currentManual = 0;

    private void Update()
    {
        // �G���^�[�L�[�Ŏ��̃X���C�h��
        if (Input.GetKeyDown(KeyCode.Return)) { PushNextManualButton(); }
        // �G�X�P�[�v�L�[�ŉ�ʂ����
        if (Input.GetKeyDown(KeyCode.Escape)) { CloseWindow(); }
    }

    /// <summary>
    /// ���̃X���C�h�����݂��邩
    /// </summary>
    /// <returns>���݂��Ă����true��Ԃ�</returns>
    private bool CanNextManual()
    {
        return currentManual + 1 < Manuals.Length;
    }

    /// <summary>
    /// ���̃X���C�h��\������
    /// </summary>
    public void PushNextManualButton()
    {
        if (!CanNextManual())
        {
            CloseWindow();
            return;
        }

        currentManual++;
        CurrenManualActive();
    }

    /// <summary>
    /// �X���C�h�̕\����Ԃ��X�V����
    /// </summary>
    private void CurrenManualActive()
    {
        for(int count = 0;count< Manuals.Length;count++)
        {
            if(count == currentManual) Manuals[count].SetActive(true);
            if(count != currentManual) Manuals[count].SetActive(false);
        }
    }

    /// <summary>
    /// �V�ѕ���ʂ����
    /// </summary>
    public override void CloseWindow()
    {
        base.CloseWindow();
        currentManual = 0;
        CurrenManualActive();
    }
}
