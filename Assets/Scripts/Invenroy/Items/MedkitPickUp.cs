using UnityEngine;

namespace Invenroy.Items
{
    public class MedkitPickUp : PickUpBase
    {
        [SerializeField] private MedkitData MedkitData;
        protected override IItem Item => MedkitData;
    }
}