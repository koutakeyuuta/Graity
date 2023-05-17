using UnityEngine;

public class WarpTouchCheck : MonoBehaviour
{
    // ���[�v�̓����蔻��
    private CircleCollider2D _warpZone;
    // �ڐG�����I�u�W�F�N�g���i�[����
    private GameObject _touchGameObject;

    // �I�u�W�F�N�g���ڐG���Ă��邩�ǂ���
    private bool _isTouchObject = false;

    private void Start()
    {
        _warpZone = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isTouchObject = true;
            _touchGameObject = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isTouchObject = true;
            _touchGameObject = collision.gameObject;
        } 
    }

    /// <summary>
    /// ���[�v�ɃI�u�W�F�N�g���ڐG���Ă��邩��Ԃ�
    /// </summary>
    /// <returns> �I�u�W�F�N�g���ڐG���Ă��邩 </returns>
    public bool IsTouchObject()
    {
        return _isTouchObject;
    }

    /// <summary>
    /// �ڐG���Ă���I�u�W�F�N�g��Ԃ�
    /// </summary>
    /// <returns> �ڐG���Ă���I�u�W�F�N�g </returns>
    public GameObject TouchObject()
    {
        return _touchGameObject;
    }

    /// <summary>
    /// ���[�v�ɕK�v�ȏ������Z�b�g����
    /// </summary>
    public void ResetFlag()
    {
        _isTouchObject = false;
        _touchGameObject = null;
    }
}