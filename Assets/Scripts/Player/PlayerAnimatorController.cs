using UnityEngine;

/// <summary>
/// プレイヤーのアニメーションを制御するクラス
/// </summary>
public class PlayerAnimatorController : MonoBehaviour
{
    // pl, Pl = Player
    // プレイヤーのアニメーターコンポーネント
    private Animator _plAnimator;

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
        SetIsRunning(isRunning);

        // 落ちているかのパラメーターをセットする
        SetIsFalling(isFalling);

        // 消滅フラグがtrueならパラメーターをセットする
        if (dissapear) SetDisapper();
    }
    
    /// <summary>
    /// 走っているかのパラメーターをセットする
    /// </summary>
    /// <param name="value"> 走っているか </param>
    private void SetIsRunning(bool value)
    {
        _plAnimator.SetBool("Run", value);
    }
    
    /// <summary>
    /// 接地中かのパラメーターをセットする
    /// </summary>
    /// <param name="value"> 落下中か </param>
    private void SetIsFalling(bool value)
    {
        _plAnimator.SetBool("Ground", value);
    }

    /// <summary>
    /// 消滅アニメーションを再生させる
    /// </summary>
    private void SetDisapper()
    {
        _plAnimator.SetTrigger("Goal");
    }
}
