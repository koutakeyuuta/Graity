using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�e�[�W�V�[����UI�𐧌䂷��N���X
/// </summary>
public class StageUIController : MonoBehaviour
{
    [Header("�t���[�cUI")]
    [SerializeField] private SpriteRenderer[] FruitsUI_spriteRenderer;

    [Header("�^�C��UI")]
    [SerializeField] private Text time_text;

    [Header("�x�X�g�^�C��UI")]
    [SerializeField] private Text bestTime_text;

    //��������
    [SerializeField] private GameObject PlusTimePrefab;

    private GameObject timePlus;
    //�����܂�

    /// <summary>
    /// �t���[�c���擾�������Ƃ�����UI��\������B
    /// </summary>
    /// <param name="fruitsNo">�t���[�c�̃i���o�[</param>
    public void FruitsUIDisplay(int fruitsNo)
    {
        FruitsUI_spriteRenderer[fruitsNo].color = new Color(1, 1, 1, 1);
    }

    /// <summary>
    /// �^�C��UI���X�V����B
    /// </summary>
    /// <param name="time">���݂̃^�C��</param>
    public void TimeUIUpdate(float time)
    {
        time_text.text = "Time " + time.ToString("F2");
    }

    /// <summary>
    /// �x�X�g�^�C��UI���X�V����B
    /// </summary>
    /// <param name="bestTime">�x�X�g�^�C��</param>
    public void BestTimeUIDisplay(float bestTime)
    {
        bestTime_text.text = "(BestTime " + bestTime.ToString("F2") + ")";
    }

    //��������
    public void TimePlusAnimation()
    {
        GameObject TimePlus = Instantiate(PlusTimePrefab, transform.position, Quaternion.identity);
        timePlus = TimePlus;
        Invoke(nameof(AnimationDestroy), 1.0f);
    }

    private void AnimationDestroy()
    {
        Destroy(timePlus);

        return;
    }
    //�����܂�
}
