using Cysharp.Threading.Tasks;
using Test.MVVM;
using UnityEngine;

namespace Test.Meta
{
    public class
        CancelableProcessingViewBehaviour : ViewBehaviour<CancelableProcessingWidgetGroupFacade,
            ICancelableProcessingViewModel>
    {
        public CancelableProcessingViewBehaviour(CancelableProcessingWidgetGroupFacade facade,
            ICancelableProcessingViewModel viewModel) : base(facade, viewModel)
        {
            facade.CancelButton.onClick.AddListener(HandleCancelButtonClicked);
        }

        private void HandleCancelButtonClicked()
        {
            ViewModel.HandleCancel();
        }

        protected override void OnInitialized()
        {
            RotateLoader();
        }

        private async void RotateLoader()
        {
            while (true)
            {
                await UniTask.Yield();
                
                if (!WidgetGroupFacade || !WidgetGroupFacade.LoaderImage)
                    return;

                var eulerAngles = WidgetGroupFacade.LoaderImage.transform.eulerAngles;
                WidgetGroupFacade.LoaderImage.transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y,
                    eulerAngles.z + Time.deltaTime * 20f);
            }
        }
    }
}