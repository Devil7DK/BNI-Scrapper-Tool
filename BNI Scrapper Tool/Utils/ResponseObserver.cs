using Gecko.Net;
using Gecko.Observers;
using System.Text;

namespace  Devil7.Automation.BNI.Scrapper.Utils
{
    public class ResponseObserver : BaseHttpModifyRequestObserver
    {
        #region Variables
        private string url = "";
        #endregion

        #region Custom Event Handlers
        public delegate void ResponseReceivedEventHandler(object sender, ResponseEventArgs e);
        public event ResponseReceivedEventHandler SearchResponseReceived;
        public event ResponseReceivedEventHandler AuthResponseReceived;

        protected virtual void OnSearchResponse(ResponseEventArgs e)
        {
            SearchResponseReceived?.Invoke(this, e);
        }
        protected virtual void OnAuthResponse(ResponseEventArgs e)
        {
            AuthResponseReceived?.Invoke(this, e);
        }
        #endregion

        #region Observer Implementation
        protected override void ObserveRequest(HttpChannel p_HttpChannel)
        {
            if (p_HttpChannel != null)
            {
                if (p_HttpChannel.Uri.AbsolutePath.Contains(Utils.Constants.SEARCH_RESPONSE_ENDPOINT) || p_HttpChannel.Uri.AbsolutePath.Contains(Utils.Constants.AUTH_RESPONSE_ENDPOINT))
                {
                    this.url = p_HttpChannel.Uri.AbsolutePath;

                    TraceableChannel oTC = p_HttpChannel.CastToTraceableChannel();
                    StreamListenerTee oStream = new StreamListenerTee();
                    oStream.Completed += Stream_Completed;
                    oTC.SetNewListener(oStream);
                }
            }
        }

        private void Stream_Completed(object sender, System.EventArgs e)
        {
            if (sender is StreamListenerTee)
            {
                StreamListenerTee oStream = sender as StreamListenerTee;
                byte[] aData = oStream.GetCapturedData();
                string sData = Encoding.ASCII.GetString(aData);

                if (url.Contains(Utils.Constants.SEARCH_RESPONSE_ENDPOINT))
                {
                    OnSearchResponse(new ResponseEventArgs(aData, sData));
                }
                else if (url.Contains(Utils.Constants.AUTH_RESPONSE_ENDPOINT))
                {
                    OnAuthResponse(new ResponseEventArgs(aData, sData));
                }
            }
        }
        #endregion
    }
}
