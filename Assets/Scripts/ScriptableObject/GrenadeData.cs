using UnityEngine;

[CreateAssetMenu(fileName = "Grenade", order = 1)]
public class GrenadeData : ScriptableObject, IItem
{
    [SerializeField] private Sprite icon;
    
    public Sprite Icon => icon;
}