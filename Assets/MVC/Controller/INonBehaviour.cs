using System.Collections;
using UnityEngine;

namespace MVC.Component
{
    public abstract class NonBehaviourController
    {
        public virtual IEnumerator Initialize()
        {
            yield return null;
        }
        public virtual IEnumerator Finalize()
        {
            yield return null;
        }
        public virtual IEnumerator Terminate()
        {
            yield return null;
        }
    }
}
