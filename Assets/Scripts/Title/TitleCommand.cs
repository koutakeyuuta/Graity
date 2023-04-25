using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �^�C�g����ʂ̃R�}���h�𐧌䂷��N���X
/// </summary>
public class TitleCommand : MonoBehaviour
{
    [Header("�}�j���A�����"), SerializeField] private GameObject PlayManualWindow;
    [Header("�R���t�B�O���"), SerializeField] private GameObject ConfigWindow;
    [Header("�Q�[���I�����"), SerializeField] private GameObject GameExitWindow;

    // ���ݑI�𒆂̃R�}���h���i�[����ϐ�
    private int SelectCommand = 0;

    private void Update()
    {
        InputSelectCommand();

        if (Input.GetKeyDown(KeyCode.Return)) PushCommand();
    }

    /// <summary>
    /// �R�}���h�I���𐧌䂷�郁�\�b�h
    /// ** �}�W�b�N�i���o�[����A�C������ **
    /// </summary>
    private void InputSelectCommand()
    {
        // �㉺�̓��͂ŃR�}���h��I������
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) SelectCommand--;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) SelectCommand++;

        // �R�}���h�̒l���N�����v����
        SelectCommand = Mathf.Clamp(SelectCommand, 0, 3);
    }

    /// <summary>
    /// �I�𒆂̃R�}���h�ɍ��킹���������s��
    /// ** �}�W�b�N�i���o�[����A�C������ **
    /// </summary>
    private void PushCommand()
    {
        if (SelectCommand == 0) PushStageSelect();
        if (SelectCommand == 1) PushPlayManual();
        if (SelectCommand == 2) PushConfig();
        if (SelectCommand == 3) PushGameExit();
    }

    /// <summary>
    /// �X�e�[�W�Z���N�g��ʂɑJ�ڂ��郁�\�b�h
    /// </summary>
    public void PushStageSelect()
    {
        SceneManager.LoadScene(SceneName.STAGESELECT);
    }

    /// <summary>
    /// �}�j���A����ʂ�\�����郁�\�b�h
    /// </summary>
    public void PushPlayManual()
    {
        PlayManualWindow.SetActive(true);
    }

    /// <summary>
    /// �ݒ��ʂ�\�����郁�\�b�h
    /// </summary>
    public void PushConfig()
    {
        ConfigWindow.SetActive(true);
    }

    /// <summary>
    /// �I����ʂ�\�����郁�\�b�h
    /// </summary>
    public void PushGameExit()
    {
        GameExitWindow.SetActive(true);
    }
}
