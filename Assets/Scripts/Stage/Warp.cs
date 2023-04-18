using UnityEngine;

/// <summary>
/// ワープの処理
/// </summary>
public class Warp : MonoBehaviour
{
    //GameObject型を変数exitで宣言します。
    public GameObject exit;
    //GameObject型を変数playerで宣言します。
    public GameObject player;

    public CircleCollider2D col;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //もしゴールオブジェクトのコライダーに接触した時の処理。
        if (other.gameObject.tag == "Player")
        {
            //Charaが接触したらexitオブジェクトの位置に移動するよ！
            player.transform.position = exit.transform.position;

            col.enabled = false;
            //entCollider.SetActive(false);
            //exit.SetActive(false);

            Invoke("TrueWarp", 1.0f);

        }
    }
    void TrueWarp()
    {
        col.enabled = true;
        //entCollider.SetActive(true);
        //exit.SetActive(true);
    }
}
