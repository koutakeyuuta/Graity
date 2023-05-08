using UnityEngine;

/// <summary>
/// �v���C���[�̑���
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("����")]
    [SerializeField] private float speed;
    [Header("�s���\")]
    [SerializeField] private bool playStart = false;
    [Header("�����蔻��̃I�t�Z�b�g")]
    [SerializeField] private Vector2 colliderOffset;
    [Header("�o������s���\�ɂȂ�܂ł̎���")]
    [SerializeField] private float appearTime;
    [Header("���ł܂ł̎���")]
    [SerializeField] private float destoryTime;

    // �ڒn���Ă邩
    private bool _onGround = false;
    // �����Ă��邩
    private bool _isRunning = false;
    // �������Ă��邩
    private bool _isFalling = false;
    // ���Ńt���O
    private bool _doDestroy = false;

    // �R���|�[�l���g (pl = Player)
    // �������Z
    private Rigidbody2D _plRigidbody;
    // �摜
    private SpriteRenderer _plSpriteRenderer;
    // �����蔻��
    private CapsuleCollider2D _plCollider;
    // �A�j���[�^�[
    private Animator _plAnimator;

    // �X�N���v�g
    // �v���C���[�̃A�j���[�V�����𐧌䂷��N���X
    private PlayerAnimatorController _plAnimController;
    // �ڒn�������������N���X
    private GroundCheck _plGroundCheck;

    private void Start()
    {
        _plRigidbody = GetComponent<Rigidbody2D>();
        _plSpriteRenderer = GetComponent<SpriteRenderer>();
        _plCollider = GetComponent<CapsuleCollider2D>();
        _plAnimator = GetComponent<Animator>();
        _plAnimController = GetComponent<PlayerAnimatorController>();
        _plGroundCheck = GetComponent<GroundCheck>();

        colliderOffset = _plCollider.offset;

        Invoke(nameof(Appear), appearTime);
    }

    private void FixedUpdate()
    {
        print(_plGroundCheck.GetIsGround());

        // �o���A�j���[�V�������I�������瓮����悤�ɂȂ�
        if (playStart)
        {
            //���ړ�
            MoveHorizontal();
            //�c�ړ�
            MoveVertical();
        }

        IsGround();
        IsFalling();
        _plAnimController.AnimParamSettings(_isRunning, _isFalling, _doDestroy);
    }

    /// <summary>
    /// ���̈ړ��𐧌䂷�郁�\�b�h
    /// </summary>
    private void MoveHorizontal()
    {
        // �E�����ɓ��͂��ꂽ��
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            // �v���C���[���E�����ɓ�����
            _plRigidbody.velocity = new Vector2(speed, _plRigidbody.velocity.y);
            // �L�����N�^�[�摜���E�Ɍ����邽�߁A���]���I�t�ɂ���
            _plSpriteRenderer.flipX = false;
            // ����A�j���[�V�������Đ�������
            _isRunning = true;

            return;
        }
        // �������ɓ��͂��ꂽ��
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            // �v���C���[���������ɓ�����
            _plRigidbody.velocity = new Vector2(-speed, _plRigidbody.velocity.y);
            // �L�����N�^�[�摜�����Ɍ����邽�߁A���]������
            _plSpriteRenderer.flipX = true;
            // ����A�j���[�V�������Đ�������
            _isRunning = true;
            
            return;
        }

        // �������̓��͂��Ȃ���
        // �v���C���[�̉������ւ̗͂��[���ɂ���
        _plRigidbody.velocity = new Vector2(0, _plRigidbody.velocity.y);
        // ����A�j���[�V�����̍Đ�����߂�
        _isRunning = false;
    }


    private void MoveVertical()
    {
        // �d�͂��������̎�
        if (_plRigidbody.gravityScale >= 0)
        {
            // �L�����N�^�[�摜�̑������Ɍ����邽�߁A���]���I�t�ɂ���
            _plSpriteRenderer.flipY = false;
            // �v���C���[�̓����蔻����摜�ɍ��킹��
            _plCollider.offset = new Vector2(colliderOffset.x, colliderOffset.y);
        }
        // �d�͂�������̎�
        if (_plRigidbody.gravityScale < 0)
        {
            // �L�����N�^�[�摜�̑�����Ɍ����邽�߁A���]������
            _plSpriteRenderer.flipY = true;
            // �v���C��̓����蔻����摜�ɍ��킹��
            _plCollider.offset = new Vector2(colliderOffset.x, -colliderOffset.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�S�[����������ŃA�j���[�V�������Đ�����
        if (collision.tag == "Goal")
        {
            _doDestroy = true;
            Invoke(nameof(Disapper), destoryTime);
        }
    }

    /// <summary>
    /// �v���C���[�̏o���𐧌䂷�郁�\�b�h
    /// </summary>
    private void Appear()
    {
        // �v���C�\�ɂ���
        playStart = true;
        // �t���[�Y�̉���
        _plRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        // �t���[�Y�̉�����A�������͂������Ȃ��Ɨ����Ă���Ȃ��̂ŗ͂�������
        _plRigidbody.AddForce(new Vector2(0, -0.1f));
    }

    /// <summary>
    /// �v���C���[�����ł����郁�\�b�h
    /// </summary>
    private void Disapper()
    {
        Destroy(gameObject);
    }

    private void IsFalling()
    {
        _isFalling = Mathf.Abs(_plRigidbody.velocity.y) > 0.0f;
    }

    private void IsGround()
    {
        _onGround = _plGroundCheck.GetIsGround();
    }
}
