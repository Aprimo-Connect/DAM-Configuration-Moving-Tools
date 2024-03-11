using System;
using System.Windows.Forms;

namespace Aprimo.DAM.ConfigurationMover
{
    public class Logger
    {
        private TextBox LoggerControl;

        public Logger(TextBox logger)
        {
            LoggerControl = logger;
        }
        public void LogInfo(string format)
        {
            LogInfoFormat(format);
        }

        private void LogInfoFormat(String format, params object[] args)
        {
            LoggerControl.AppendText(string.Format(format, args) + Environment.NewLine);
        }
    }
}
