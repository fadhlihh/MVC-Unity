using UnityEngine;

namespace MVC.Component
{
    public abstract class ControllerBehaviour : MonoBehaviour
    {

    }

    public abstract class ControllerBehaviour<TModel> : MonoBehaviour
    where TModel : Model, new()
    {
        private TModel _model;

        private void Awake()
        {
            _model = new TModel();
        }
    }

    public abstract class ControllerBehaviour<TModel, TIModel> : MonoBehaviour
    where TModel : Model, TIModel, new()
    where TIModel : IModel
    {
        private TModel _model;

        public TIModel Model
        {
            get
            {
                return _model;
            }
        }

        private void Awake()
        {
            _model = new TModel();
        }
    }

    public abstract class ObjectControllerBehaviour<TView> : MonoBehaviour
    where TView : View
    {
        [SerializeField]
        private TView _view;
    }

    public abstract class ObjectControllerBehaviour<TModel, TView> : MonoBehaviour
    where TModel : Model, new()
    where TView : View
    {
        [SerializeField]
        private TView _view;

        private TModel _model;

        private void Awake()
        {
            _model = new TModel();
        }
    }

    public abstract class ObjectControllerBehaviour<TModel, TIModel, TView> : MonoBehaviour
    where TModel : Model, TIModel, new()
    where TIModel : IModel
    where TView : View<TIModel>
    {
        [SerializeField]
        private TView _view;

        private TModel _model;

        public TIModel Model
        {
            get
            {
                return _model;
            }
        }

        private void Awake()
        {
            _model = new TModel();
            _view.Initialize(Model);
        }

        protected void UpdateRenderData()
        {
            _view.Render(Model);
        }
    }
}
