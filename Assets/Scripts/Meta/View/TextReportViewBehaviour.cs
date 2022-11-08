using Test.MVVM;

namespace Test.Meta
{
    public class TextReportViewBehaviour : ViewBehaviour<TextReportWidgetFacade, ITextReportViewModel>
    {

        public string HeaderText
        {
            set => WidgetGroupFacade.HeaderText.text = value;
            get => WidgetGroupFacade.HeaderText.text;
        }

        public TextReportViewBehaviour(TextReportWidgetFacade facade, ITextReportViewModel viewModel) : base(
            facade, viewModel)
        {
        }

        protected override void OnInitialized()
        {
            WidgetGroupFacade.ReportText.text = ViewModel.Report;
            ViewModel.Report.OnValueChanged +=
                (sender, arg) => WidgetGroupFacade.ReportText.text = arg.Value;
        }
    }
}