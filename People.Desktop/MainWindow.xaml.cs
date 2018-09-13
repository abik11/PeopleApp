using People.Desktop.Infrastructure;
using People.Desktop.Properties;
using People.Resources.Strings;
using System.Windows;

namespace People.Desktop
{
   public partial class MainWindow : Window
   {
      public ViewModel.PeopleViewModel peopleViewModelObject;

      public MainWindow()
      {
         InitializeComponent();
      }

      private void PeopleViewControl_Loaded(object sender, RoutedEventArgs e)
      {
         this.peopleViewModelObject = new ViewModel.PeopleViewModel(new MessageBoxService());
         this.peopleViewModelObject.LoadPeople();

         PeopleViewControl.DataContext = this.peopleViewModelObject;
         miFile.DataContext = this.peopleViewModelObject;
      }

      private void MenuItem_pl_Click(object sender, RoutedEventArgs e)
      {
         SetLanguage("pl-PL");
      }

      private void MenuItem_en_Click(object sender, RoutedEventArgs e)
      {
         SetLanguage("en-GB");
      }

      private void SetLanguage(string lang)
      {
         MessageBoxResult result = MessageBox
            .Show(Strings.DoYouWantToChangeLanguage, Strings.ChangeConfirmation, 
            MessageBoxButton.YesNo, MessageBoxImage.Question);

         if (result == MessageBoxResult.Yes)
         {
            Settings.Default.Lang = lang;
            Settings.Default.Save();
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
         }
      }
   }
}