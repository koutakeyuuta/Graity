using UnityEngine;

/// <summary>
/// BGMを再生するオブジェクトがシーンを遷移しても消滅しないようにする。
/// あんまり気に食わないからもっといい方法がないかを探してください。
/// 理屈もよくわからず使ってます。
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
