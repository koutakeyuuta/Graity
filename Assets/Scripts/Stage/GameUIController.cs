using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [Header("�X�e�[�W�i���o�[")]
    [SerializeField] private int stageNo;

    [Header("�^�C��UI")]
    [SerializeField] private Text timeText;
    [Header("�x�X�g�^�C��UI")]
    [SerializeField] private Text bestTimeText;
    [Header("�e�t���[�cUI")]
    [SerializeField] private GameObject[] FruitsSprite;

    [Header("�t���[�c�}�l�[�W���[")]
    [SerializeField] private FruitsManager fruitsManager;
    [Header("�Q�[���^�C�}�[")]
    [SerializeField] private GameTimer gameTimer;
    // �x�X�g�^�C���̐���
    private BestTime _bestTime;

    private void Start()
    {
        _bestTime = new BestTime(stageNo);

        BestTimeUpdate();
    }

    private void Update()
    {
        FruitsUpdate();
        TimerUpdate();
    }

    /// <summary>
    /// �e�t���[�c��UI�̍X�V
    /// </summary>
    private void FruitsUpdate()
    {
        for (int i = 0; i < FruitsSprite.Length; i++)
        {
            if (!fruitsManager.GetCollected()[i]) continue;

            FruitsSprite[i].SetActive(true);
        }
    }

    /// <summary>
    /// �^�C�}�[�̍X�V
    /// </summary>
    private void TimerUpdate()
    {
        timeText.text = gameTimer.TimeLimit().ToString("F2");
    }

    /// <summary>
    /// �x�X�g�^�C���̍X�V
    /// </summary>
    private void BestTimeUpdate()
    {
        bestTimeText.text = _bestTime.GetBestTime().ToString("F2");
    }

    /// <summary>
    /// �Q�[�����X�^�[�g�������̏���
    /// </summary>
    public void GameStartUI()
    {
        gameTimer.TimerStart();
    }

    /// <summary>
    /// �Q�[�����N���A�������̏���
    /// </summary>
    public void GameCleardUI()
    {
        gameTimer.TimerStop();
    }

    /// <summary>
    /// ���Ԑ؂ꂩ�ǂ�����Ԃ�
    /// </summary>
    /// <returns> ���Ԑ؂ꂩ�ǂ��� </returns>
    public bool IsTimeUp()
    {
        return gameTimer.TimeLimit() < 0;
    }
}
