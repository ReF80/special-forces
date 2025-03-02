using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    [SerializeField] public Image healthBarImage;
    [SerializeField] public Player player;

    private void Start() => player.health.OnHit += HealthBar;
    private void HealthBar() => healthBarImage.fillAmount = player.health.Value / player.health.MaxValue;
}
