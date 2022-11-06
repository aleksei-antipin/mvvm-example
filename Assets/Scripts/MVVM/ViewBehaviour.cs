namespace Test.MVVM
{
    public abstract class ViewBehaviour
    {
        public abstract WidgetGroupFacade BaseFacade { get; }

        public void Initialize()
        {
            OnInitialized();
        }

        public void Deactivate()
        {
            OnDeactivate();
        }

        protected virtual void OnInitialized()
        {
        }

        protected virtual void OnDeactivate()
        {
        }
    }

    public abstract class ViewBehaviour<T1, T2> : ViewBehaviour where T1 : WidgetGroupFacade where T2 : IViewModel
    {
        #region Ctor

        protected ViewBehaviour(T1 facade, T2 viewModel)
        {
            WidgetGroupFacade = facade;
            ViewModel = viewModel;
        }

        #endregion

        public override WidgetGroupFacade BaseFacade => WidgetGroupFacade;
        public T1 WidgetGroupFacade { get; }

        public T2 ViewModel { get; }
    }
}