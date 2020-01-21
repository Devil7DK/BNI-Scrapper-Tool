using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using Serilog;
using System.Collections.ObjectModel;
using  Devil7.Automation.BNI.Scrapper.Utils;

namespace  Devil7.Automation.BNI.Scrapper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            ObservableCollection<Models.LogEvent>  LogEvents = new ObservableCollection<Models.LogEvent>();
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.ObservableCollectionSink(LogEvents)
                .CreateLogger();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_Main(LogEvents));
        }
    }
}
