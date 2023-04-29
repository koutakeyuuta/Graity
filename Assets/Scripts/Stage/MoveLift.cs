using UnityEngine;

/// <summary>
/// ���t�g�̐���
/// </summary>
public class MoveLift : MonoBehaviour
{
    [SerializeField] private bool XY = true;

    private Vector2 StartPosition;
    private Vector2 CurrentPosition;
    private bool Reverse = true;

    private void Start()
    {
        StartPosition = transform.position;
        CurrentPosition = transform.position;
    }

    private void FixedUpdate()
    {
        CurrentPosition = transform.position;

        if (XY) UpDown();
        if (!XY) LeftRight();
    }

    /// <summary>
    /// �㉺�ɓ�������
    /// </summary>
    private void UpDown()
    {
        // ���t�g�̈ʒu�������ɂ����false
        if (StartPosition.y + 0.7f < CurrentPosition.y) Reverse = false;
        // ���t�g�̈ʒu�����艺�ɂ����true
        if (StartPosition.y + -0.7f > CurrentPosition.y) Reverse = true;

        // ���ɂ���Ώ�ɗ͂�������
        if (Reverse) transform.Translate(new Vector2(0.0f, 1.0f) * Time.deltaTime);
        // ��ɂ���Ή��ɗ͂�������
        if (!Reverse) transform.Translate(new Vector2(0.0f, -1.0f) * Time.deltaTime);
    }

    /// <summary>
    /// ���E�ɓ�������
    /// </summary>
    private void LeftRight()
    {
        // ���t�g�̈ʒu�����荶�ɂ����false
        if (StartPosition.x + 0.7f < CurrentPosition.x) Reverse = false;
        // ���t�g�̈ʒu������E�ɂ����true
        if (StartPosition.x + -0.7f > CurrentPosition.x) Reverse = true;

        // �E�ɂ���΍��ɗ͂�������
        if (Reverse) transform.Translate(new Vector2(1.0f, 0.0f) * Time.deltaTime);
        // ���ɂ���ΉE�ɗ͂�������
        if (!Reverse) transform.Translate(new Vector2(-1.0f, 0.0f) * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && !XY)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            float vect = 0;
            if (Reverse) vect = 1;
            if (!Reverse) vect = -1; 
            playerController.TakeForce(new Vector2(50.0f * vect, 0.0f));
            print(true);
        }
    }
}
