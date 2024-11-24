using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtns : MonoBehaviour
{
    public void LoadGame() //Button Start Game
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() // Button Exit
    {
        Application.Quit();
    }
}
