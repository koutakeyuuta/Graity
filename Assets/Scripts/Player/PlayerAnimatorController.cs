using UnityEngine;

/// <summary>
/// �v���C���[�̃A�j���[�V�����𐧌䂷��N���X
/// </summary>
public class PlayerAnimatorController : MonoBehaviour
{
    // pl, Pl = Player
    // �v���C���[�̃A�j���[�^�[�R���|�[�l���g
    private Animator _plAnimator;
    // �v���C���[��Rigidbody
    private Rigidbody2D _plRigidbody;

    private void Start()
    {
        _plAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// �A�j���[�V�����̃p�����[�^�[���Z�b�g���郁�\�b�h
    /// Anim = Animation, Param = Parameter
    /// </summary>
    /// <param name="isRunning"> �����Ă��邩 </param>
    /// <param name="isFalling"> �����Ă��邩 </param>
    /// <param name="dissapear"> ���Ńt���O </param>
    public void AnimParamSettings(bool isRunning, bool isFalling, bool dissapear)
    {
        // �����Ă��邩�̃p�����[�^�[���Z�b�g����
        if (isRunning) SetRun();
        if (!isRunning) SetNoRun();

        // �����Ă��邩�̃p�����[�^�[���Z�b�g����
        if (isFalling) SetFall();
        if (!isFalling) SetNoFall();

        // ���Ńt���O��true�Ȃ�p�����[�^�[���Z�b�g����
        if (dissapear) SetDisapper();
    }

    /// <summary>
    /// �����Ă����Ԃɂ���
    /// </summary>
    private void SetRun()
    {
        _plAnimator.SetBool("Run", true);
    }

    /// <summary>
    /// �����Ă��Ȃ���Ԃɂ���
    /// </summary>
    private void SetNoRun()
    {
        _plAnimator.SetBool("Run", false);
    }

    /// <summary>
    /// �����Ă����Ԃɂ���
    /// </summary>
    private void SetFall()
    {
        _plAnimator.SetBool("Fall", true);
    }

    /// <summary>
    /// �����Ă��Ȃ���Ԃɂ���
    /// </summary>
    private void SetNoFall()
    {
        _plAnimator.SetBool("Fall", false);
    }

    /// <summary>
    /// ���ŃA�j���[�V�������Đ�������
    /// </summary>
    private void SetDisapper()
    {
        _plAnimator.SetTrigger("Goal");
    }
}
