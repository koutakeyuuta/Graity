using UnityEngine;

public class FruitsManager : MonoBehaviour
{
    [Header("�e�t���[�c")]
    [SerializeField] private GameObject[] Fruits;

    // �e�t���[�c���擾������
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
    /// �擾�󋵂����Z�b�g����
    /// </summary>
    private void ResetCollected()
    {
        for (int i = 0; i<_collectedFruits.Length; i++)
        {
            _collectedFruits[i] = false;
        }
    }

    /// <summary>
    /// �擾�󋵂�Ԃ�
    /// </summary>
    /// <returns></returns>
    public bool[] GetCollected()
    {
        return _collectedFruits;
    }

    /// <summary>
    /// �擾�󋵂��m�F����
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
