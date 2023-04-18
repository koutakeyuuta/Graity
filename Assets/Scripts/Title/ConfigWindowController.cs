using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigWindowController : MonoBehaviour
{
    [Header("音量調節スライダー"), SerializeField] private Slider VolumeSlider;
    [Header("クレジット画面"), SerializeField] private GameObject CreditWindow;
    [Header("データ削除画面"), SerializeField] private GameObject DataDeleteWindow;
    // 音量調整スライダーの値を受け取る変数
    private float volumeSliderValue;

    private void Update()
    {
        ChangedVolumeSlider();
        SettingVolumeInfomation();
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

    /// <summary>
    /// クレジット画面を開く
    /// </summary>
    public void OpenCreditWindow()
    {
        CreditWindow.SetActive(true);
    }

    /// <summary>
    /// データ削除画面を開く
    /// </summary>
    public void OpenDataDeleteWindow()
    {
        DataDeleteWindow.SetActive(true);
    }

    /// <summary>
    /// Configウィンドウを閉じる
    /// </summary>
    public void CloseConfigWindow()
    {
        gameObject.SetActive(false);
    }
}
