using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �^�C�g����ʂ̃R�}���h�𐧌�
/// </summary>
public class TitleWindow : BaseWindow
{
    // ���ݑI�𒆂̃R�}���h���i�[����ϐ�
    private int SelectCommand = 0;

    private void Update()
    {
        InputSelectCommand();

        if (IsActiveNextWindows() == false)
        {
            if (Input.GetKeyDown(KeyCode.Return)) PushCommand();
        }
    }

    /// <summary>
    /// �R�}���h�I���𐧌䂷�郁�\�b�h
    /// </summary>
    private void InputSelectCommand()
    {
        // �㉺�̓��͂ŃR�}���h��I������
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) SelectCommand--;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) SelectCommand++;

        // �R�}���h�̒l��1����|�b�v�A�b�v�̐��̊ԂŐ�������
        SelectCommand = Mathf.Clamp(SelectCommand, 0, nextWindows.Length);
    }

    /// <summary>
    /// �I�����ꂽ�R�}���h�����s����
    /// </summary>
    public void PushCommand()
    {
        if (SelectCommand == 0)
        {
            LoadStageSelectScene();
            return;
        }
        nextWindows[SelectCommand - 1].OpenWindow();
    }

    /// <summary>
    /// �X�e�[�W�I����ʂɑJ�ڂ���
    /// </summary>
    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene(SceneName.STAGESELECT);
    }
}
