using UnityEngine;

/// <summary>
/// ÉäÉtÉgÇÃêßå‰
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

    private void UpDown()
    {
        if (StartPosition.y + 0.7f < CurrentPosition.y) Reverse = false;
        if (StartPosition.y + -0.7f > CurrentPosition.y) Reverse = true;

        if (Reverse) transform.Translate(new Vector2(0.0f, 1.0f) * Time.deltaTime);
        if (!Reverse) transform.Translate(new Vector2(0.0f, -1.0f) * Time.deltaTime);
    }

    private void LeftRight()
    {
        if (StartPosition.x + 0.7f < CurrentPosition.x) Reverse = false;
        if (StartPosition.x + -0.7f > CurrentPosition.x) Reverse = true;

        if (Reverse) transform.Translate(new Vector2(1.0f, 0.0f) * Time.deltaTime);
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
