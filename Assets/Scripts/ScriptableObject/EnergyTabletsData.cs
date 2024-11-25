using UnityEngine;

[CreateAssetMenu(fileName = "SpeedBoost", order = 1)]
public class EnergyTabletsData : ScriptableObject, IItem
{
    [SerializeField] private Sprite icon;
    [SerializeField] private int addSpeed;
    public Sprite Icon => icon;
    public int AddSpeed => addSpeed;
}