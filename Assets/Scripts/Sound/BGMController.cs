using UnityEngine;

/// <summary>
/// BGM�̐���
/// </summary>
public class BGMController : MonoBehaviour
{
    // BGM
    [Header("BGM"), SerializeField] AudioSource BGM;

    // ���ʂ��i�[����
    private float volume;

    private void Update()
    {
        GetVolume();
        SetVolume();
    }

    /// <summary>
    /// �ۑ�����Ă��鉹�ʂ��擾���郁�\�b�h
    /// </summary>
    private void GetVolume()
    {
        volume = BGMInfomation.VolumeCheck();
    }

    /// <summary>
    /// BGM�̉��ʂ�ݒ肷�郁�\�b�h
    /// </summary>
    private void SetVolume()
    {
        BGM.volume = volume;
    }
}
