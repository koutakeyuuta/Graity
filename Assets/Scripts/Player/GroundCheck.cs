using UnityEngine;

/// <summary>
/// �ڒn�������������N���X
/// </summary>
public class GroundCheck : MonoBehaviour
{
    // �ڒn���
    private bool onGround;

    /// <summary>
    /// �ڒn��Ԃ�Ԃ�
    /// </summary>
    /// <returns> �ڒn��� </returns>
    public bool IsGround()
    {
        return onGround;
    }

    // �ڒn����
    private void OnTriggerEnter2D(Collider2D collision)
    {
            onGround = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
            onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            onGround = false;
    }
}
