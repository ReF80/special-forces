using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MissionTextTyping : MonoBehaviour
{
    public Text textUI;
    public GameObject panelMessengeMenu;
    public string startText;
    public string winText;
    
    public float delay;
    [SerializeField] private AudioSource startMessengeAudioSource;
    [SerializeField] private AudioSource radioInterference;
    [SerializeField] private AudioSource winMissionAudioSource;

    private string _currentText = "";

    private void Start() => StartCoroutine(StartMission());

    public void WinMissionFunc()
    {
        panelMessengeMenu.SetActive(true);
        StartCoroutine(WinMission());
    }

    public void LoseMission()
    {
        radioInterference.Play();
    }

    private IEnumerator StartMission()
    {
        radioInterference.Play();
        for (int i = 0; i < startText.Length; i++)
        {
            _currentText = startText.Substring(0, i);
            textUI.text = _currentText;
            yield return new WaitForSeconds(delay);
        }
        _currentText = "";
        yield return new WaitForSeconds (1);
        SeekMessengerMenu();
    }

    private IEnumerator WinMission()
    {
        radioInterference.Play();
        winMissionAudioSource.Play();
        for (int i = 0; i < winText.Length; i++)
        {
            _currentText = winText.Substring(0, i);
            textUI.text = _currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds (1);
        SeekMessengerMenu();
    }

    void SeekMessengerMenu()
    {
        panelMessengeMenu.SetActive(false);
    }
    
}
