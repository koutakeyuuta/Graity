using UnityEngine;
using UnityEngine.UI;

public class ConfigWindow : BaseWindow
{
    [Header("音量調節スライダー")]
    [SerializeField] private Slider VolumeSlider;
    // 音量調整スライダーの値を受け取る変数
    private float volumeSliderValue;

    private void Update()
    {
        ChangedVolumeSlider();
        SettingVolumeInfomation();

        if (IsActiveNextWindows() == true) CloseWindow();
    }

    /// <summary>
    /// 音量調節スライダーの値を保存する
    /// </summary>
    private void ChangedVolumeSlider()
    {
        volumeSliderValue = VolumeSlider.value;
    }

    /// <summary>
    /// BGMの情報を記憶するクラスに設定を保存する
    /// </summary>
    private void SettingVolumeInfomation()
    {
        BGMInfomation.VolumeSetting(volumeSliderValue);
    }
}
