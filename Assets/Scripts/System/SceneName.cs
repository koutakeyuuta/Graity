using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// �V�[���̖��O��萔�����Ďg���܂킹��悤�ɂ���N���X�B
/// �V�[�����̕ύX���������Ƃ��͂�����ύX����B
/// �ő�X�e�[�W���̕ύX�������ōs���B
/// </summary>
public class SceneName : MonoBehaviour
{
    //�^�C�g���V�[��
    public const string TITLE = "TitleScene";    
    
    //�X�e�[�W�Z���N�g�V�[��
    public const string STAGESELECT = "StageSelectScene"; 

    //�X�e�[�W�V�[��(���̒萔�Ƀv���X�ŃX�e�[�W�i���o�[���L�q���Ă�������)
    public const string STAGE = "Stage";
}
