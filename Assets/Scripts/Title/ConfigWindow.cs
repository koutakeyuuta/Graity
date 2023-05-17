using UnityEngine;
using UnityEngine.UI;

public class ConfigWindow : BaseWindow
{
    [Header("���ʒ��߃X���C�_�[")]
    [SerializeField] private Slider VolumeSlider;
    // ���ʒ����X���C�_�[�̒l���󂯎��ϐ�
    private float volumeSliderValue;

    private void Update()
    {
        ChangedVolumeSlider();
        SettingVolumeInfomation();

        if (IsActiveNextWindows() == true) CloseWindow();
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
}
