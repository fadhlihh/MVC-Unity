using UnityEngine;

namespace MVC.Component
{
    public abstract class View<TIModel> : MonoBehaviour where TIModel : IModel
    {
        public abstract void Initialize(TIModel model);
        public abstract void Render(TIModel model);
    }

    public abstract class View : MonoBehaviour
    {

    }
}
