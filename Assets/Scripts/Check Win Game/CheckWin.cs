using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class CheckWin : MonoBehaviour
{
    [SerializeField] private int enemyLiveForWin = 0;
    [SerializeField] private int enemyLive = 3;
    [SerializeField] private GameObject panel;
    [SerializeField] public MissionTextTyping missionTextTyping;
    
    public void Check()
    {
        CheckDieEnemy();
    }

    private async Task CheckDieEnemy()
    {
        enemyLive--;
        Debug.Log("Count Enemy - " + enemyLive);
        if (enemyLive == enemyLiveForWin)
        {
            missionTextTyping.WinMissionFunc();
            panel.SetActive(true);
            await Task.Delay(5000);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
