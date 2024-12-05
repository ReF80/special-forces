using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Invenroy.Grenade
{
    public class DelayedAction : MonoBehaviour
    {
        [SerializeField]
        private float _delay;
        [SerializeField]
        private UnityEvent _event;

        private void Start()
        {
            StartCoroutine(Delay());
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(_delay);
            _event.Invoke();
        }
    }
}