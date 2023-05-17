using UnityEngine;

/// <summary>
/// �v���C���[�̃A�j���[�V�����𐧌䂷��N���X
/// </summary>
public class PlayerAnimatorController : MonoBehaviour
{
    // pl, Pl = Player
    // �v���C���[�̃A�j���[�^�[�R���|�[�l���g
    private Animator _plAnimator;

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
        SetIsRunning(isRunning);

        // �����Ă��邩�̃p�����[�^�[���Z�b�g����
        SetIsFalling(isFalling);

        // ���Ńt���O��true�Ȃ�p�����[�^�[���Z�b�g����
        if (dissapear) SetDisapper();
    }
    
    /// <summary>
    /// �����Ă��邩�̃p�����[�^�[���Z�b�g����
    /// </summary>
    /// <param name="value"> �����Ă��邩 </param>
    private void SetIsRunning(bool value)
    {
        _plAnimator.SetBool("Run", value);
    }
    
    /// <summary>
    /// �ڒn�����̃p�����[�^�[���Z�b�g����
    /// </summary>
    /// <param name="value"> �������� </param>
    private void SetIsFalling(bool value)
    {
        _plAnimator.SetBool("Ground", value);
    }

    /// <summary>
    /// ���ŃA�j���[�V�������Đ�������
    /// </summary>
    private void SetDisapper()
    {
        _plAnimator.SetTrigger("Goal");
    }
}
