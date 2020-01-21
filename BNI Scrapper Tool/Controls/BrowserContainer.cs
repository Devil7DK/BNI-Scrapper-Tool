using Gecko;

namespace  Devil7.Automation.BNI.Scrapper.Controls
{
    public partial class BrowserContainer : DevExpress.XtraEditors.XtraUserControl
    {
        public GeckoWebBrowser Browser { get => this.browser; }

        public BrowserContainer()
        {
            InitializeComponent();

            this.browser.Navigated += Browser_Navigated;
            this.browser.ProgressChanged += Browser_ProgressChanged;
            this.browser.StatusTextChanged += Browser_StatusTextChanged;
        }

        #region Events
        private void Browser_Navigated(object sender, GeckoNavigatedEventArgs e)
        {
            txt_URL.EditValue = e.Uri.ToString();
        }

        private void Browser_ProgressChanged(object sender, GeckoProgressEventArgs e)
        {
            if (e.MaximumProgress == 0)
            {
                prog_Document.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                prog_Document.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                prog_Document.EditValue = ((e.CurrentProgress / e.MaximumProgress) * 100);
            }
        }

        private void Browser_StatusTextChanged(object sender, System.EventArgs e)
        {
            lbl_Status.Caption = ((GeckoWebBrowser)sender).StatusText;
        } 
        #endregion
    }
}
