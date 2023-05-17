using UnityEngine;

/// <summary>
/// �ڒn�������������N���X
/// </summary>
public class GroundCheck : MonoBehaviour
{
    [Header("�n�ʔ���̃��C���[")]
    [SerializeField] private LayerMask groundLayer;
    [Header("�ڒn����")]
    [SerializeField] private BoxCollider2D groundCheckCollider;

    // �ڒn�����Y���̃I�t�Z�b�g
    private float _groundCheckColliderOffset;
    // �ڒn���
    private bool _isGround;

    private void Start()
    {
        _groundCheckColliderOffset = groundCheckCollider.offset.y;
    }

    /// <summary>
    /// �ڒn��Ԃ�Ԃ�
    /// </summary>
    /// <returns> �ڒn��� </returns>
    public bool GetIsGround()
    {
        IsGround();
        return _isGround;
    }

    /// <summary>
    /// �ڒn����𔽓]������
    /// true�Œʏ�(������),false�Ŕ��](�����)
    /// </summary>
    public void ReverseColliderOffset(bool gravity)
    {
        if (gravity)
        {
            groundCheckCollider.offset = new Vector2(groundCheckCollider.offset.x, _groundCheckColliderOffset);
            return;
        }

        if (!gravity)
        {
            groundCheckCollider.offset = new Vector2(groundCheckCollider.offset.x, -_groundCheckColliderOffset);
            return;
        }
    }

    /// <summary>
    /// �ڒn����
    /// </summary>
    private void IsGround()
    {
        _isGround = groundCheckCollider.IsTouchingLayers(groundLayer);
    }
}
