using UnityEngine;

/// <summary>
/// �v���C���[�ɊO������͂�������N���X
/// </summary>
public class PlayerGetForce : MonoBehaviour
{
    // pl = player
    // �v���C���[��Rigidbody2D
    private Rigidbody2D _plRb;

    private void Start()
    {
        // �R���|�[�l���g�̎擾
        _plRb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// �󂯎�����͂��v���C���[�ɉ����郁�\�b�h
    /// </summary>
    /// <param name="force"></param>
    public void GetForce(Vector2 force)
    {
        _plRb.AddForce(force);
    }
}
