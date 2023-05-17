using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        Vector3 pos = myTransform.position;
        float y = pos.y;
        float z = pos.z;

        transform.Translate(-0.01f, 0, 0);
        if (transform.position.x < -10.24f)
        {
            transform.position = new Vector3(10.24f, y, z);
        }
    }
}
