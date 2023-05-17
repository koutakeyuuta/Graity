using UnityEngine;

public class FruitsManager : MonoBehaviour
{
    [Header("各フルーツ")]
    [SerializeField] private GameObject[] Fruits;

    // 各フルーツを取得したか
    private bool[] _collectedFruits = new bool[FruitsInfomation.FRUITSCOUNT];

    private void Start()
    {
        ResetCollected();
    }

    private void Update()
    {
        CheakCollectedFruits();
    }

    /// <summary>
    /// 取得状況をリセットする
    /// </summary>
    private void ResetCollected()
    {
        for (int i = 0; i<_collectedFruits.Length; i++)
        {
            _collectedFruits[i] = false;
        }
    }

    /// <summary>
    /// 取得状況を返す
    /// </summary>
    /// <returns></returns>
    public bool[] GetCollected()
    {
        return _collectedFruits;
    }

    /// <summary>
    /// 取得状況を確認する
    /// </summary>
    private void CheakCollectedFruits()
    {
        for (int i = 0; i < Fruits.Length; i++)
        {
            if (Fruits[i] == null)
            {
                _collectedFruits[i] = true;
            }
        }
    }
}
