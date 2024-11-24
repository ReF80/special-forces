using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] public Image health_Bar;
    [SerializeField] public Player Player;

    public void Update()
    {
        health_Bar.fillAmount = Player.health.Value / Player.health.MaxValue;
    }
}
