using UnityEngine;

namespace Invenroy.Items
{
    public class EnergyTabletsPickUp : PickUpBase
    {
        [SerializeField] private EnergyTabletsData energyTabletsData;
        protected override IItem Item => energyTabletsData;
    }
}