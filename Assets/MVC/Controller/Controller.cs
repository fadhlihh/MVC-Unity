namespace MVC.Component
{
    public class Controller : NonBehaviourController
    {

    }

    public class Controller<TModel> : NonBehaviourController where TModel : Model, new()
    {
        private TModel _model;

        public Controller()
        {
            _model = new TModel();
        }
    }

    public class Controller<TModel, TIModel> : NonBehaviourController
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

    public class ObjectController<TView> : NonBehaviourController where TView : View
    {
        private TView _view;

        public virtual void SetView(TView view)
        {
            _view = view;
        }
    }

    public class ObjectController<TModel, TView> : NonBehaviourController
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

    public class ObjectController<TModel, TIModel, TView> : NonBehaviourController
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
