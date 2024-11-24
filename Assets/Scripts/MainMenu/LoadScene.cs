using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    void Start() // Load Scene Main Menu
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(2);
    }
}
