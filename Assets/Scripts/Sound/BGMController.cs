using UnityEngine;

public class BGMController : MonoBehaviour
{
    [Header("BGM"), SerializeField] AudioSource BGM;

    private float volume;

    private void Start()
    {
        BGM = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetVolume();
        SetVolume();
    }

    private void GetVolume()
    {
        volume = BGMInfomation.VolumeCheck();
    }

    private void SetVolume()
    {
        BGM.volume = volume;
    }
}
