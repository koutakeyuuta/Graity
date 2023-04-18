using UnityEngine;

/// <summary>
/// フルーツを制御するクラス
/// </summary>
public class FruitsCollect : MonoBehaviour
{
    [SerializeField] private AudioClip CollectSound;

    private AudioSource fruitsAudio;
    private Animator animator;

    // フルーツが取得され消滅する時に使う変数
    private bool destroyFlag = false;  

    private void Start()
    {
        animator = GetComponent<Animator>();
        fruitsAudio = GetComponent<AudioSource>();
        fruitsAudio.volume = BGMInfomation.VolumeCheck();
    }

    private void Update()
    {
        // Collectアニメーションが一回再生されたらオブジェクトを消滅させる
        // ここは改善出来そうですが今はこれで動作するのでそのままにしています
        if (destroyFlag && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1
                 && animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 2)
        {
            Collected();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーと接触した場合
        if (collision.tag == "Player")
        {
            //Collectアニメーションに遷移する
            animator.SetTrigger("Collect");
            destroyFlag = true;
            fruitsAudio.PlayOneShot(CollectSound);
        }
    }

    /// <summary>
    /// フルーツを消滅させる
    /// </summary>
    private void Collected()
    {
        Destroy(gameObject);
    }
}
