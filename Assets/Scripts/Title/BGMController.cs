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
        CatchVolume();
        Setting();
    }

    private void CatchVolume()
    {
        volume = BGMInfomation.VolumeCheck();
    }

    private void Setting()
    {
        BGM.volume = volume;
    }
}
