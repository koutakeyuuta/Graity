using UnityEngine;

/// <summary>
/// ���[�v�̏���
/// </summary>
public class Warp : MonoBehaviour
{
    //GameObject�^��ϐ�exit�Ő錾���܂��B
    public GameObject exit;
    //GameObject�^��ϐ�player�Ő錾���܂��B
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
        //�����S�[���I�u�W�F�N�g�̃R���C�_�[�ɐڐG�������̏����B
        if (other.gameObject.tag == "Player")
        {
            //Chara���ڐG������exit�I�u�W�F�N�g�̈ʒu�Ɉړ������I
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
