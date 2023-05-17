using UnityEngine;

/// <summary>
/// ���[�v�̏���
/// </summary>
public class Warp : MonoBehaviour
{
    [Header("���[�v�]�[��")]
    [SerializeField] private GameObject warpZone1;
    [SerializeField] private GameObject warpZone2;

    // ���[�v�Ƀv���C���[���G�ꂽ���̔����Ԃ�
    private WarpTouchCheck _warpZone1TouchCheck;
    private WarpTouchCheck _warpZone2TouchCheck;
    
    // ���[�v�]�[���̃|�W�V���� (Pos = Position)
    private Vector2 _warpZone1Pos;
    private Vector2 _warpZone2Pos;

    private void Start()
    {
        _warpZone1TouchCheck = warpZone1.GetComponent<WarpTouchCheck>();
        _warpZone2TouchCheck = warpZone2.GetComponent<WarpTouchCheck>();

        _warpZone1Pos = warpZone1.transform.position;
        _warpZone2Pos = warpZone2.transform.position;
    }

    private void Update()
    {
        if (_warpZone1TouchCheck.IsTouchObject())
        {
            // ���[�v����
            WarpObject(_warpZone1TouchCheck.TouchObject(), _warpZone2Pos);
            // ���[�v�ɕK�v�ȏ������Z�b�g����
            _warpZone1TouchCheck.ResetFlag();
        }

        if (_warpZone2TouchCheck.IsTouchObject())
        {
            // ���[�v����
            WarpObject(_warpZone2TouchCheck.TouchObject(), _warpZone1Pos);
            // ���[�v�ɕK�v�ȏ������Z�b�g����
            _warpZone2TouchCheck.ResetFlag();
        }
    }

    /// <summary>
    /// ���[�v����
    /// </summary>
    /// <param name="touchObject"> ���[�v����I�u�W�F�N�g </param>
    /// <param name="warpPos"> ���[�v�����̈ʒu </param>
    private void WarpObject(GameObject touchObject, Vector2 warpPos)
    {
        // ���[�v���~����
        StopWarp();
        // �I�u�W�F�N�g�����[�v������
        touchObject.transform.position = warpPos;
        // ��莞�Ԍ�Ƀ��[�v���ċN������
        Invoke(nameof(RebootWarp), 1.0f);
    }

    /// <summary>
    /// ���[�v���~����
    /// </summary>
    private void StopWarp()
    {
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// ���[�v���Ăяo��������
    /// </summary>
    private void RebootWarp()
    {
        this.gameObject.SetActive(true);
    }
}
