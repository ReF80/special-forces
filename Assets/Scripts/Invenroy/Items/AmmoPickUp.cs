using UnityEngine;

namespace Invenroy.Items
{
    public class AmmoPickUp : PickUpBase
    {
        [SerializeField] private AmmoData AmmoData;
        protected override IItem Item => AmmoData;
    }
}