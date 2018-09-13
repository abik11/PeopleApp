using People.Desktop.Properties;
using People.Resources.Strings;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace People.Desktop
{
   public partial class App : Application
   {
      protected override void OnStartup(StartupEventArgs e)
      {
         base.OnStartup(e);
         Configuration.AutomapperConfiguration.Configure();

         string lang = Settings.Default.Lang;

         Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
         Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);

         FrameworkElement.LanguageProperty.OverrideMetadata
            (typeof(FrameworkElement),
            new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
      }

      private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
      {
         MessageBox.Show(Strings.UnhandledExceptionMessage + " " + e.Exception.Message,
            Strings.UnhandledException, MessageBoxButton.OK, MessageBoxImage.Warning);
         e.Handled = true;
      }
   }
}