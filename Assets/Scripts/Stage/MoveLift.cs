using UnityEngine;

/// <summary>
/// リフトの制御
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
    /// 上下に動く処理
    /// </summary>
    private void UpDown()
    {
        // リフトの位置が基準より上にあればfalse
        if (StartPosition.y + 0.7f < CurrentPosition.y) Reverse = false;
        // リフトの位置が基準より下にあればtrue
        if (StartPosition.y + -0.7f > CurrentPosition.y) Reverse = true;

        // 下にあれば上に力を加える
        if (Reverse) transform.Translate(new Vector2(0.0f, 1.0f) * Time.deltaTime);
        // 上にあれば下に力を加える
        if (!Reverse) transform.Translate(new Vector2(0.0f, -1.0f) * Time.deltaTime);
    }

    /// <summary>
    /// 左右に動く処理
    /// </summary>
    private void LeftRight()
    {
        // リフトの位置が基準より左にあればfalse
        if (StartPosition.x + 0.7f < CurrentPosition.x) Reverse = false;
        // リフトの位置が基準より右にあればtrue
        if (StartPosition.x + -0.7f > CurrentPosition.x) Reverse = true;

        // 右にあれば左に力を加える
        if (Reverse) transform.Translate(new Vector2(1.0f, 0.0f) * Time.deltaTime);
        // 左にあれば右に力を加える
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
