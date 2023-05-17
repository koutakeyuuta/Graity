using UnityEngine;

/// <summary>
/// �d�͔��]����
/// </summary>
public class Gravity : MonoBehaviour
{
    [Header("�ڒn����")]
    [SerializeField] private GroundCheck groundCheck;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ReverseGravity();
    }

    /// <summary>
    /// �d�͂𔽓]������
    /// </summary>
    private void ReverseGravity()
    {
        if (!groundCheck.GetIsGround()) return;
        rb.gravityScale = -rb.gravityScale;
    }
}

