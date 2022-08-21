using System.Collections;
using MVC.Utility;

namespace MVC.Component
{
    public class Controller<TController> : IController
    where TController : Controller<TController>
    {
        public virtual IEnumerator Initialize()
        {
            DependencyInjection.Instance.RegisterDependencies(typeof(TController), this);
            yield return null;
        }
        public virtual IEnumerator Finalize()
        {
            DependencyInjection.Instance.InjectDependencies(this);
            yield return null;
        }
        public virtual IEnumerator Terminate()
        {
            DependencyInjection.Instance.UnregisterDependencies(typeof(TController));
            yield return null;
        }
    }

    public class Controller<TController, TModel> : Controller<TController>
    where TController : Controller<TController, TModel>
    where TModel : Model, new()
    {
        private TModel _model;

        public Controller()
        {
            _model = new TModel();
        }
    }

    public class Controller<TController, TModel, TIModel> : Controller<TController>
    where TController : Controller<TController, TModel, TIModel>
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

        public Controller()
        {
            _model = new TModel();
        }
    }

    public class ObjectController<TController, TView> : Controller<TController>
    where TController : ObjectController<TController, TView>
    where TView : View
    {
        private TView _view;

        public virtual void SetView(TView view)
        {
            _view = view;
        }
    }

    public class ObjectController<TController, TModel, TView> : Controller<TController>
    where TController : ObjectController<TController, TModel, TView>
    where TModel : Model, new()
    where TView : View

    {
        private TView _view;
        private TModel _model;

        public ObjectController()
        {
            _model = new TModel();
        }

        public virtual void SetView(TView view)
        {
            _view = view;
        }
    }

    public class ObjectController<TController, TModel, TIModel, TView> : Controller<TController>
    where TController : ObjectController<TController, TModel, TIModel, TView>
    where TModel : Model, TIModel, new()
    where TIModel : IModel
    where TView : View<TIModel>

    {
        private TView _view;
        private TModel _model;

        public TIModel Model
        {
            get
            {
                return _model;
            }
        }

        public ObjectController()
        {
            _model = new TModel();
        }

        public virtual void SetView(TView view)
        {
            _view = view;
            _view.Initialize(Model);
        }

        protected void UpdateRenderData()
        {
            _view.Render(Model);
        }
    }
}
