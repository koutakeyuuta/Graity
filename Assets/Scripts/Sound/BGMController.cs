using UnityEngine;

/// <summary>
/// BGMの制御
/// </summary>
public class BGMController : MonoBehaviour
{
    // BGM
    [Header("BGM"), SerializeField] AudioSource BGM;

    // 音量を格納する
    private float volume;

    private void Update()
    {
        GetVolume();
        SetVolume();
    }

    /// <summary>
    /// 保存されている音量を取得するメソッド
    /// </summary>
    private void GetVolume()
    {
        volume = BGMInfomation.VolumeCheck();
    }

    /// <summary>
    /// BGMの音量を設定するメソッド
    /// </summary>
    private void SetVolume()
    {
        BGM.volume = volume;
    }
}
