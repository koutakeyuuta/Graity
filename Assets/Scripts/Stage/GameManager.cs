using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �X�e�[�W�V�[��(�Q�[���V�[��)�𐧌䂷��N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("�X�e�[�W�i���o�[")] 
    [SerializeField] private int stageNo;

    [Header("�Q�[��UI�R���g���[���[")]
    [SerializeField] private GameUIController gameUIController;

    [SerializeField] private GameObject stageClearUI_Object;
    [Header("�S�[���R���g���[���[")]
    [SerializeField] private GoalController goalController;

    // �S�[����̏�������񂾂����s���邽�߂����̕ϐ�(�ǂ��Ȃ�)
    private bool _goalMethodStop = true;

    private void Update()
    {
        // ���삪���͂����ƃ^�C�}�[�X�^�[�g
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) 
                      || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && _goalMethodStop)
        {
            gameUIController.GameStartUI();
        }

        // ���Ԑ؂�Ń��X�^�[�g
        if (gameUIController.IsTimeUp()) RestartStage();

        // �S�[�������Ƃ��̏���
        if (goalController.IsGoal()�@&& _goalMethodStop) StageClear();
    }

    /// <summary>
    /// �X�e�[�W���N���A�����ۂ̏���
    /// </summary>
    private void StageClear()
    {
        // �X�e�[�W�N���A��̏�������񂾂����s���邽��(�ǂ��Ȃ�)
        _goalMethodStop = false;

        // �X�e�[�W�󋵂�ۑ��B
        //StageInfomation.StageSave(stageNo, _gameTimer.ClearTime(), _collectedFruits);

        // �X�e�[�W�N���A���UI��\������B
        stageClearUI_Object.SetActive(true);
    }

    /// <summary>
    /// �X�e�[�W�������[�h(���X�^�[�g)����B
    /// �X�e�[�W�i���o�[�u999�v�̓X�e�[�W�x�[�X�V�[�����w���B
    /// </summary>
    public void RestartStage()
    {
        if(stageNo == 999)
        {
            SceneManager.LoadScene("StageBase");
            return;
        }
        SceneManager.LoadScene(SceneName.STAGE + stageNo);
    }

    /// <summary>
    /// �X�e�[�W�Z���N�g�V�[���ɑJ�ڂ���B
    /// </summary>
    public void TransitionStageSelectScene()
    {
        SceneManager.LoadScene(SceneName.STAGESELECT);
    }

    /// <summary>
    /// ���̃X�e�[�W�֑J�ڂ���B
    /// �Ō�̃X�e�[�W�ł̓X�e�[�W�Z���N�g�V�[���ɑJ�ڂ���B
    /// �X�e�[�W�x�[�X�V�[���ł��X�e�[�W�Z���N�g�V�[���ɑJ�ڂ���B
    /// </summary>
    public void TransitionNextStage()
    {
        if ((stageNo + 1) >= StageInfomation.STAGECOUNT) TransitionStageSelectScene();
        else SceneManager.LoadScene(SceneName.STAGE + (stageNo + 1));
    }
}
