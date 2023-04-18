using UnityEngine;

/// <summary>
/// �S�[���̐���
/// </summary>
public class GoalController : MonoBehaviour
{
    [SerializeField] private AudioClip GoalSound;

    private AudioSource GoalSource;

    //�S�[���̃A�j���[�^�[
    private Animator animator;

    private bool goalFlag = false;

    private void Start()
    {
        animator= GetComponent<Animator>();
        GoalSource = GetComponent<AudioSource>();
        GoalSource.volume = BGMInfomation.VolumeCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �v���C���[�Ƃ̐ڐG��
        if (collision.tag == "Player")
        {
            // �A�j���[�V�����̍Đ�
            animator.SetTrigger("Goal");
            // �S�[���̔���
            goalFlag = true;
            // �I�[�f�B�I�̍Đ�
            GoalSource.PlayOneShot(GoalSound);
        }
    }

    /// <summary>
    /// �S�[�������Ԃ�
    /// </summary>
    /// <returns> �S�[������ </returns>
    public bool IsGoal()
    {
        return goalFlag;
    }
}
