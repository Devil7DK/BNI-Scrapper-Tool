using  Devil7.Automation.BNI.Scrapper.Models;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace  Devil7.Automation.BNI.Scrapper.Utils
{
    class ObservableCollectionSink : ILogEventSink
    {
        #region Variables
        private ObservableCollection<LogEvent> logCollection;
        #endregion

        #region Constructor
        public ObservableCollectionSink(ObservableCollection<LogEvent> logCollection)
        {
            this.logCollection = logCollection;
        }
        #endregion

        #region ILogEventSink Implements
        public void Emit(Serilog.Events.LogEvent logEvent)
        {
            if (logCollection != null)
            {
                if (Dispatcher.CurrentDispatcher.CheckAccess())
                {
                    logCollection.Add(new LogEvent(logEvent.Timestamp, logEvent.Level, logEvent.RenderMessage()));
                }
                else
                {
                    Dispatcher.CurrentDispatcher.InvokeAsync(() => logCollection.Add(new LogEvent(logEvent.Timestamp, logEvent.Level, logEvent.RenderMessage())));
                }
            }
        }
        #endregion
    }

    public static class SinkExtensions
    {
        public static LoggerConfiguration ObservableCollectionSink(this LoggerSinkConfiguration loggerSinkConfiguration, ObservableCollection<LogEvent> logCollection)
        {
            return loggerSinkConfiguration.Sink(new ObservableCollectionSink(logCollection), Serilog.Events.LogEventLevel.Verbose);
        }
    }
}
