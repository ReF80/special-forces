using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtns : MonoBehaviour
{
    [SerializeField]
    public GameObject panel;
    
    public void OpenOptions() => panel.SetActive(true);
    public void CloseOptions() => panel.SetActive(false);
    
    public void LoadGame() => SceneManager.LoadScene(0);

    public void ExitGame() => Application.Quit();
}
