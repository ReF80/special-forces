using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    public static bool isPaused;
    public bool isSkills = true;
    public GameObject panelSkills;
    public GameObject GreenImage;
    public GameObject RedImage;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause11();
                if (isSkills)
                {
                    CloseSkills();
                }
                else
                {
                    OpenSkills();
                }
            }
        }
    }

    public void Resume()
    {
        panel.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false;
        isSkills = false;
    }

    private void Pause11()
    {
        panel.SetActive(true); 
        Time.timeScale = 0f; 
        isPaused = true; 
    }
    
    public void OpenSkills()
    {
        panelSkills.SetActive(true);
        isSkills = true;
    }

    public void CloseSkills()
    {
        panelSkills.SetActive(false);
        isSkills = false;

    }
    
    public void SkillUp()
    {
        GreenImage.SetActive(true);
        RedImage.SetActive(false);
    }
    public void Quit() => SceneManager.LoadScene("MainMenu");
}
