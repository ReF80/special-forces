using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject panel;
    [SerializeField] private GameObject[] healthGreenImage = new GameObject[6];
    [SerializeField] private GameObject[] healthRedImage = new GameObject[6];
    [SerializeField] private GameObject[] speedGreenImage = new GameObject[6];
    [SerializeField] private GameObject[] speedRedImage = new GameObject[6];
    [SerializeField] private int healthLevel = 1;
    [SerializeField] private int speedLevel = 1;
    public static bool IsPaused;
    public GameObject panelSkills;
    public Player player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
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
        IsPaused = false;
    }

    private void StartPause()
    {
        panel.SetActive(true); 
        Time.timeScale = 0f; 
        IsPaused = true; 
    }
    
    public void OpenSkills() => panelSkills.SetActive(true);
    public void CloseSkills() => panelSkills.SetActive(false);
    
    public void HealthSkillUp()
    {
        for (int i = 0; i < healthLevel; i++)
        {
            healthGreenImage[i].SetActive(true);
            healthRedImage[i].SetActive(false);
        }

        player.health.MaxValue += 10;
        healthLevel += 1;
    }

    public void SpeedSkillUp()
    {
        for (int i = 0; i < speedLevel; i++)
        {
            speedGreenImage[i].SetActive(true);
            speedRedImage[i].SetActive(false);
        }

        player.speed += 1;
        speedLevel += 1;
    }
    public void Quit() => SceneManager.LoadScene("MainMenu");
}
