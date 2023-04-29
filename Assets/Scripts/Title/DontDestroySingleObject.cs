using UnityEngine;

/// <summary>
/// BGM���Đ�����I�u�W�F�N�g���V�[����J�ڂ��Ă����ł��Ȃ��悤�ɂ���B
/// ����܂�C�ɐH��Ȃ���������Ƃ������@���Ȃ�����T���Ă��������B
/// �������悭�킩�炸�g���Ă܂��B
/// </summary>
public class DontDestroySingleObject : MonoBehaviour
{
    public static DontDestroySingleObject Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
