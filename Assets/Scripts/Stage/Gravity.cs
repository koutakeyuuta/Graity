using UnityEngine;

/// <summary>
/// èdóÕîΩì]èàóù
/// </summary>
public class Gravity : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private GroundCheck groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ReverseGravity();
    }

    private void ReverseGravity()
    {
        if (!groundCheck.GetIsGround()) return;
        rb.gravityScale = -rb.gravityScale;
    }
}

