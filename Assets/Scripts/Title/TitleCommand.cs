using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleCommand : MonoBehaviour
{
    [Header("マニュアル画面"), SerializeField] private GameObject PlayManualWindow;
    [Header("コンフィグ画面"), SerializeField] private GameObject ConfigWindow;
    [Header("ゲーム終了画面"), SerializeField] private GameObject GameExitWindow;

    private int SelectCommand = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) SelectCommand--;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) SelectCommand++;
        SelectCommand = Mathf.Clamp(SelectCommand, 0, 3);

        if (Input.GetKeyDown(KeyCode.Return)) PushCommand();
    }

    private void PushCommand()
    {
        if (SelectCommand == 0) PushStageSelect();
        if (SelectCommand == 1) PushPlayManual();
        if (SelectCommand == 2) PushConfig();
        if (SelectCommand == 3) PushGameExit();
    }

    public void PushStageSelect()
    {
        SceneManager.LoadScene(SceneName.STAGESELECT);
    }

    public void PushPlayManual()
    {
        PlayManualWindow.SetActive(true);
    }

    public void PushConfig()
    {
        ConfigWindow.SetActive(true);
    }

    public void PushGameExit()
    {
        GameExitWindow.SetActive(true);
    }
}
