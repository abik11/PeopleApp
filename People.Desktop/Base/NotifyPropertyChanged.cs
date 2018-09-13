using System.ComponentModel;

namespace People.Desktop.Base
{
   public class NotifyPropertyChanged : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      public void OnPropertyChanged(string propertyName)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
