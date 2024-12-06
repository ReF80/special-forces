using System.Collections;
using UnityEngine;

namespace Core.Code.Actions
{
    public class DelayedActionInvoker : ActionInvoker
    {
        [SerializeField]
        private float _delay;

        private void Start()
        {
            StartCoroutine(Delay());
        }

        private IEnumerator Delay()
        {
            yield return new WaitForSeconds(_delay);
            InvokeAction();
        }
    }
}