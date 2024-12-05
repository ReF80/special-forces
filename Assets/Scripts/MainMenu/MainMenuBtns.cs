using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtns : MonoBehaviour
{
    public void LoadGame() //Button Start Game
    {
        Controller.Instance.MusicSource.volume = 0;
        SceneManager.LoadScene(1);
    }

    public void ExitGame() // Button Exit
    {
        Application.Quit();
    }
}
