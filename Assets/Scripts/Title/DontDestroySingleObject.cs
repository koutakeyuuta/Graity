using UnityEngine;

/// <summary>
/// BGMを再生するオブジェクトがシーンを遷移しても消滅しないようにする。
/// あんまり気に食わないのでもっといい方法がないかを探してください。
/// </summary>
public class DontDestroySingleObject : MonoBehaviour
{
    public static DontDestroySingleObject Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
