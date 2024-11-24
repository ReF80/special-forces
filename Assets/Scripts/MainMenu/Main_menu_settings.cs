using UnityEngine;

public class Main_menu_settings : MonoBehaviour
{
    [SerializeField]
    public GameObject panel;
    
    public void Options()
    {
        panel.SetActive(true);
    }
    public void ExitOptions()
    {
        panel.SetActive(false);
    }
}
