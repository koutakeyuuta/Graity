using UnityEngine;

/// <summary>
/// d—Í”½“]ˆ—
/// </summary>
public class Gravity : MonoBehaviour
{
    [Header("Ú’n”»’è")]
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
    /// d—Í‚ğ”½“]‚³‚¹‚é
    /// </summary>
    private void ReverseGravity()
    {
        if (!groundCheck.GetIsGround()) return;
        rb.gravityScale = -rb.gravityScale;
    }
}

