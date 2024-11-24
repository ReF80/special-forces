using UnityEngine;

[CreateAssetMenu(fileName = "Med kit", order = 1)]
public class MedkitData : ScriptableObject, IItem
{
    [SerializeField] private Sprite icon;
    [SerializeField] private float health;
    
    public Sprite Icon => icon;
    public float Health => health;
}
