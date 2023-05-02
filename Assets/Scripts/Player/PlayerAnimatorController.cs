using UnityEngine;

/// <summary>
/// プレイヤーのアニメーションを制御するクラス
/// </summary>
public class PlayerAnimatorController : MonoBehaviour
{
    // pl, Pl = Player
    // プレイヤーのアニメーターコンポーネント
    private Animator _plAnimator;
    // プレイヤーのRigidbody
    private Rigidbody2D _plRigidbody;

    private void Start()
    {
        _plAnimator = GetComponent<Animator>();
    }

    /// <summary>
    /// アニメーションのパラメーターをセットするメソッド
    /// Anim = Animation, Param = Parameter
    /// </summary>
    /// <param name="isRunning"> 走っているか </param>
    /// <param name="isFalling"> 落ちているか </param>
    /// <param name="dissapear"> 消滅フラグ </param>
    public void AnimParamSettings(bool isRunning, bool isFalling, bool dissapear)
    {
        // 走っているかのパラメーターをセットする
        if (isRunning) SetRun();
        if (!isRunning) SetNoRun();

        // 落ちているかのパラメーターをセットする
        if (isFalling) SetFall();
        if (!isFalling) SetNoFall();

        // 消滅フラグがtrueならパラメーターをセットする
        if (dissapear) SetDisapper();
    }

    /// <summary>
    /// 走っている状態にする
    /// </summary>
    private void SetRun()
    {
        _plAnimator.SetBool("Run", true);
    }

    /// <summary>
    /// 走っていない状態にする
    /// </summary>
    private void SetNoRun()
    {
        _plAnimator.SetBool("Run", false);
    }

    /// <summary>
    /// 落ちている状態にする
    /// </summary>
    private void SetFall()
    {
        _plAnimator.SetBool("Fall", true);
    }

    /// <summary>
    /// 落ちていない状態にする
    /// </summary>
    private void SetNoFall()
    {
        _plAnimator.SetBool("Fall", false);
    }

    /// <summary>
    /// 消滅アニメーションを再生させる
    /// </summary>
    private void SetDisapper()
    {
        _plAnimator.SetTrigger("Goal");
    }
}
