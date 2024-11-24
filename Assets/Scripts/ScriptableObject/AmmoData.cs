using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", order = 1)]
public class AmmoData : ScriptableObject, IItem
{
    [SerializeField] private Sprite icon;
    [SerializeField] private int ammo;
    
    public Sprite Icon => icon;
    public int Ammo => ammo;
}