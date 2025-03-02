using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    public static bool isPaused;
    public GameObject panelSkills;
    public GameObject GreenImage;
    public GameObject RedImage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                CloseSkills();
            }
            else
            {
                StartPause();
            }
        }
    }

    private void Resume()
    {
        panel.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
    }

    private void StartPause()
    {
        panel.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true; 
    }
    
    public void OpenSkills() => panelSkills.SetActive(true);
    public void CloseSkills() => panelSkills.SetActive(false);
    
    public void SkillUp()
    {
        GreenImage.SetActive(true);
        RedImage.SetActive(false);
    }
    public void Quit() => SceneManager.LoadScene("MainMenu");
}
