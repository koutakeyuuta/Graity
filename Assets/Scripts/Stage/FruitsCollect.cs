using UnityEngine;

/// <summary>
/// �t���[�c�𐧌䂷��N���X
/// </summary>
public class FruitsCollect : MonoBehaviour
{
    [SerializeField] private AudioClip CollectSound;

    private AudioSource fruitsAudio;
    private Animator animator;

    // �t���[�c���擾������ł��鎞�Ɏg���ϐ�
    private bool destroyFlag = false;  

    private void Start()
    {
        animator = GetComponent<Animator>();
        fruitsAudio = GetComponent<AudioSource>();
        fruitsAudio.volume = BGMInfomation.VolumeCheck();
    }

    private void Update()
    {
        // Collect�A�j���[�V���������Đ����ꂽ��I�u�W�F�N�g�����ł�����
        // �����͉��P�o�������ł������͂���œ��삷��̂ł��̂܂܂ɂ��Ă��܂�
        if (destroyFlag && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
                 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 2)
        {
            Collected();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�v���C���[�ƐڐG�����ꍇ
        if (collision.tag == "Player")
        {
            //Collect�A�j���[�V�����ɑJ�ڂ���
            animator.SetTrigger("Collect");
            destroyFlag = true;
            fruitsAudio.PlayOneShot(CollectSound);
        }
    }

    /// <summary>
    /// �t���[�c�����ł�����
    /// </summary>
    private void Collected()
    {
        Destroy(gameObject);
    }
}
