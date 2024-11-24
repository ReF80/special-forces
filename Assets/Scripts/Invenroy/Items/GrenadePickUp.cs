using UnityEngine;

namespace Invenroy.Items
{
    public class GrenadePickUp : PickUpBase
    {
        [SerializeField] private GrenadeData GrenadeData;
        protected override IItem Item => GrenadeData;
    }
}