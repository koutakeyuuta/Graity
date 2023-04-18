using UnityEngine;

public class GameExitWindow : MonoBehaviour
{
    public void GameExit()
    {
        Application.Quit();
    }

    public void CloseGameExitWindow()
    {
        gameObject.SetActive(false);
    }
}
