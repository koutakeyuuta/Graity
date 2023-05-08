using UnityEngine;

/// <summary>
/// �ڒn�������������N���X
/// </summary>
public class GroundCheck : MonoBehaviour
{
    [Header("�n�ʔ���̃��C���[")]
    [SerializeField] private LayerMask groundLayer;

    // �ڒn���
    private bool _isGround;

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
    /// �ڒn����
    /// </summary>
    private void IsGround()
    {
        _isGround = Physics2D.Linecast(transform.position,
                                       transform.position - transform.up,
                                       groundLayer);
    }
}
