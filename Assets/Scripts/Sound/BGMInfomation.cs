using UnityEngine;

/// <summary>
/// �I�[�f�B�I�����Ǘ�����N���X
/// ���̓X�^�e�B�b�N�ϐ��ŕۑ����Ă��邪
/// ������͕ʂ̋L�����@���̗p������
/// </summary>
public class BGMInfomation : MonoBehaviour
{
    // �S�̃{�����[�����L������ϐ�
    private static float VolumeParameter = 0.5f;

    /// <summary>
    /// �󂯎�����l���L�����邽�߂̃��\�b�h
    /// </summary>
    /// <param name="changedValue"> ���͂��ꂽ�ύX��̃{�����[���̒l </param>
    /// <exception cref="System.Exception"> ���͂��ꂽ�l���͈͊O�̎��ɏ�������� </exception>
    public static void VolumeSetting(float changedValue)
    {
        // �G���[����
        if(changedValue < 0) throw new System.Exception("�������l��ݒ肵�Ă�������");
        if(changedValue > 1) throw new System.Exception("�������l��ݒ肵�Ă�������");

        // �l�̊i�[
        VolumeParameter = changedValue;
    }

    /// <summary>
    /// ���݂̑S�̃{�����[���̒l��Ԃ����\�b�h
    /// </summary>
    /// <returns> ���݂̑S�̃{�����[�� </returns>
    public static float VolumeCheck()
    {
        // �S�̃{�����[����Ԃ�
        return VolumeParameter;
    }
}