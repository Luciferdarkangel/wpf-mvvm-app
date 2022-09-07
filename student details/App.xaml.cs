using System;
using System.Diagnostics;
using System.Windows;

namespace student_details
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            BindingErrorListener.Listen(m => MessageBox.Show(m));
        }
    }

    public class BindingErrorListener : TraceListener
    {
        private Action<string> logAction = (s) => { };
        public static void Listen(Action<string> logAction)
        {
            PresentationTraceSources.DataBindingSource.Listeners
                .Add(new BindingErrorListener() { logAction = logAction });
        }
        public override void Write(string message) { }
        public override void WriteLine(string message)
        {
            logAction(message);
        }
    }
}
