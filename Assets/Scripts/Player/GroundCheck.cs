using UnityEngine;

/// <summary>
/// �ڒn���菈��
/// </summary>
public class GroundCheck : MonoBehaviour
{
    private bool isGround;

    // ���茋�ʂ�Ԃ�
    public bool IsGround()
    {
        return isGround;
    }

    //�ڒn����
    private void OnTriggerEnter2D(Collider2D collision)
    {
            isGround = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
            isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            isGround = false;
    }
}
