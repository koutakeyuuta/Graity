using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �X�e�[�W�V�[��(�Q�[���V�[��)�𐧌䂷��N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("�X�e�[�W�i���o�[")] 
    [SerializeField] private int stageNo;

    [Header("�X�e�[�WUI�R���g���[���[")]
    [SerializeField] private StageUIController stageUIController;

    [Header("�X�e�[�W�N���AUI")]
    [SerializeField] private GameObject stageClearUI_Object;

    [Header("�S�[���R���g���[���[")]
    [SerializeField] private GoalController goalController;

    [Header("�t���[�c�I�u�W�F�N�g")]
    [SerializeField] private GameObject[] Fruits_Object;

    private GameTimer _gameTimer;

    // �t���[�c���擾���Ă��邩�ǂ����B
    private bool[] _collectedFruits = new bool[FruitsInfomation.FRUITSCOUNT];

    // �S�[����̏�������񂾂����s���邽�߂����̕ϐ�(�ǂ��Ȃ�)
    private bool _goalMethodStop = true;

    private void Start()
    {
        // �t���[�c�̎擾�󋵂�������
        FruitsCollectDelete();
        // �X�e�[�W�̃x�X�g�^�C��UI���X�V
        stageUIController.BestTimeUIDisplay(StageInfomation.stageBestTime[stageNo]);
    }

    private void Update()
    {
        // ���삪���͂����ƃ^�C�}�[�X�^�[�g
        if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space) 
                      || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && _goalMethodStop)
        {
            _gameTimer.TimerStart();
        }

        // ���Ԑ؂�Ń��X�^�[�g
        if (_gameTimer.ClearTime() <= 0) RestartStage();

        // �e�t���[�c�����ł�������(�擾���ꂽ)�𔻒肷��B
        for(int count = 0; count < Fruits_Object.Length; count++) 
        {
            // �t���[�c������ and �t���[�c���擾����Ă����(�����������J��Ԃ��Ȃ��悤�ɂ��Ă���)
            if(Fruits_Object[count] == null && !_collectedFruits[count])
            {
                // �t���[�cUI���X�V����B
                stageUIController.FruitsUIDisplay(count);
                // �t���[�c���擾�������Ƃ��L������B
                _collectedFruits[count] = true;

                // �������Ԓǉ�
                _gameTimer.AddTime();
                // ���Ԓǉ��A�j���[�V����
                stageUIController.TimePlusAnimation();
            }
        }

        // �S�[�������Ƃ��̏���
        if (goalController.IsGoal()�@&& _goalMethodStop) StageClear();

        // �X�e�[�W�̃N���A�^�C��UI���X�V����
        stageUIController.TimeUIUpdate(_gameTimer.ClearTime());
    }

    /// <summary>
    /// �t���[�c�̎擾�󋵂�����������B
    /// </summary>
    private void FruitsCollectDelete()
    {
        for(int fruitsNo = 0; fruitsNo < _collectedFruits.Length; fruitsNo++)
        {
            _collectedFruits[fruitsNo] = false;
        }
    }

    /// <summary>
    /// �X�e�[�W���N���A�����ۂ̏���
    /// </summary>
    private void StageClear()
    {
        // �X�e�[�W�N���A��̏�������񂾂����s���邽��(�ǂ��Ȃ�)
        _goalMethodStop = false;

        // �^�C�}�[�X�g�b�v�B
        _gameTimer.TimerStop();

        // �X�e�[�W�󋵂�ۑ��B
        StageInfomation.StageSave(stageNo, _gameTimer.ClearTime(), _collectedFruits);

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
