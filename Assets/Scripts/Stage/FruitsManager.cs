using UnityEngine;

public class FruitsManager : MonoBehaviour
{
    [Header("各フルーツ")]
    [SerializeField] private GameObject[] Fruits;

    private bool[] _collectedFruits = new bool[FruitsInfomation.FRUITSCOUNT];

    private void Start()
    {
        SetCollected();
    }

    private void SetCollected()
    {
        for(int i = 0; i<_collectedFruits.Length; i++)
        {
            _collectedFruits[i] = false;
        }
    }
}
