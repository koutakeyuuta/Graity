using UnityEngine;

/// <summary>
/// Ú’n”»’èˆ—
/// </summary>
public class GroundCheck : MonoBehaviour
{
    private bool isGround;

    // ”»’èŒ‹‰Ê‚ğ•Ô‚·
    public bool IsGround()
    {
        return isGround;
    }

    //Ú’n”»’è
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
