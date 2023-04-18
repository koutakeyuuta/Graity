using UnityEngine;

/// <summary>
/// ゴールの制御
/// </summary>
public class GoalController : MonoBehaviour
{
    [SerializeField] private AudioClip GoalSound;

    private AudioSource GoalSource;

    //ゴールのアニメーター
    private Animator animator;

    private bool goalFlag = false;

    private void Start()
    {
        animator= GetComponent<Animator>();
        GoalSource = GetComponent<AudioSource>();
        GoalSource.volume = BGMInfomation.VolumeCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーとの接触で
        if (collision.tag == "Player")
        {
            // アニメーションの再生
            animator.SetTrigger("Goal");
            // ゴールの判定
            goalFlag = true;
            // オーディオの再生
            GoalSource.PlayOneShot(GoalSound);
        }
    }

    /// <summary>
    /// ゴール判定を返す
    /// </summary>
    /// <returns> ゴール判定 </returns>
    public bool IsGoal()
    {
        return goalFlag;
    }
}
