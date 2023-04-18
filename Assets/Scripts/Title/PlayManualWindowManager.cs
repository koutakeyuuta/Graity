using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayManualWindowManager : MonoBehaviour
{
    [Header("�}�j���A��"), SerializeField] private GameObject[] Manuals;

    //���ݕ\������Ă���}�j���A���̔ԍ�
    private int currentManual = 0;

    /// <summary>
    /// ���̃}�j���A�������݂��邩
    /// </summary>
    /// <returns>���݂��Ă����true��Ԃ�</returns>
    private bool CanNextManual()
    {
        return currentManual + 1 < Manuals.Length;
    }

    /// <summary>
    /// ���̃}�j���A����\������
    /// </summary>
    public void PushNextManualButton()
    {
        if (!CanNextManual())
        {
            CloseManualWindow();
            return;
        }

        currentManual++;
        CurrenManualActive();
    }

    /// <summary>
    /// �}�j���A���̕\����Ԃ��X�V����
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
    /// �}�j���A���E�B���h�E�����
    /// </summary>
    public void CloseManualWindow()
    {
        gameObject.SetActive(false);
        currentManual = 0;
        CurrenManualActive();
    }
}
