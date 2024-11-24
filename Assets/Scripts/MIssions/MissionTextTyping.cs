using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MissionTextTyping : MonoBehaviour
{
    public Text textUI;
    public GameObject _panelMessengeMenu;
    public string StartText;
    public string WinText;
    
    public float delay;
    [SerializeField] AudioSource startMessengeAudioSource;
    [SerializeField] private AudioSource _radioInterference;

    [SerializeField] private AudioSource winMissionAudioSource;

    private string currentText = "";

    void Start()
    {
        StartCoroutine(StartMission());
    }

    public void WinMissionFunc()
    {
        _panelMessengeMenu.SetActive(true);
        StartCoroutine(WinMission());
    }

    public void LoseMission()
    {
        _radioInterference.Play();
        
    }

    IEnumerator StartMission()
    {
        _radioInterference.Play();
        for (int i = 0; i < StartText.Length; i++)
        {
            currentText = StartText.Substring(0, i);
            textUI.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        currentText = "";
        yield return new WaitForSeconds (1);
        SeekMessengerMenu();
    }

    IEnumerator WinMission()
    {
        _radioInterference.Play();
        winMissionAudioSource.Play();
        for (int i = 0; i < WinText.Length; i++)
        {
            currentText = WinText.Substring(0, i);
            textUI.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds (1);
        SeekMessengerMenu();
    }

    void SeekMessengerMenu()
    {
        _panelMessengeMenu.SetActive(false);
    }
    
}
