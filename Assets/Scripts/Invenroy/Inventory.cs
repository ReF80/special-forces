using player;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Slot[] slots;
    [SerializeField] private Player _player;
    private PLayerShooting _pLayerShooting;
    private IItem[] _items = new IItem[5];
    public EnergyTabletsBoost energyTabletsBoost;
    public ForwardMover ForwardMover; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItems(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItems(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItems(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItems(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UseItems(4);
        }
    }

    private void UseItems(int index)
    {
        IItem item = _items[index];
        switch (item)
        {
            case MedkitData medkit:
                Debug.Log("Используется предмет medkit");
                _player.health.Add(medkit.Health);
                break;
            case AmmoData ammo:
                Debug.Log("Используется предмет ammo");
                _player.shoot.AddAmmo(ammo.Ammo);
                break;
            case EnergyTabletsData energyTablets:
                Debug.Log("Используется предмет energy tablets");
                energyTabletsBoost.Boost(energyTablets.AddSpeed);
                break;
        }
        _items[index] = null;
        slots[index].SetSprite(null);
    }

    public bool TryAddItem(IItem item)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] != null)
            {
                continue;
            }
            _items[i] = item;
            slots[i].SetSprite(item.Icon);
            Debug.Log("Добавлен объект в " + _items + item);
            return true;
        }
        return false;
    }
}
