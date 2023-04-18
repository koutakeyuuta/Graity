using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigWindowController : MonoBehaviour
{
    [Header("���ʒ��߃X���C�_�["), SerializeField] private Slider VolumeSlider;
    [Header("�N���W�b�g���"), SerializeField] private GameObject CreditWindow;
    [Header("�f�[�^�폜���"), SerializeField] private GameObject DataDeleteWindow;
    // ���ʒ����X���C�_�[�̒l���󂯎��ϐ�
    private float volumeSliderValue;

    private void Update()
    {
        ChangedVolumeSlider();
        SettingVolumeInfomation();
    }

    /// <summary>
    /// ���ʒ��߃X���C�_�[�̒l��ۑ�����
    /// </summary>
    private void ChangedVolumeSlider()
    {
        volumeSliderValue = VolumeSlider.value;
    }

    /// <summary>
    /// BGM�̏����L������N���X�ɐݒ��ۑ�����
    /// </summary>
    private void SettingVolumeInfomation()
    {
        BGMInfomation.VolumeSetting(volumeSliderValue);
    }

    /// <summary>
    /// �N���W�b�g��ʂ��J��
    /// </summary>
    public void OpenCreditWindow()
    {
        CreditWindow.SetActive(true);
    }

    /// <summary>
    /// �f�[�^�폜��ʂ��J��
    /// </summary>
    public void OpenDataDeleteWindow()
    {
        DataDeleteWindow.SetActive(true);
    }

    /// <summary>
    /// Config�E�B���h�E�����
    /// </summary>
    public void CloseConfigWindow()
    {
        gameObject.SetActive(false);
    }
}
