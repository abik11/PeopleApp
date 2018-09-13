using System.Windows;

namespace People.Desktop.Infrastructure
{
   public class MessageBoxService : IMessageBoxService
   {
      public void Show(string message, string title)
      {
         MessageBox.Show(message, title);
      }

      public void Show(string message, string title, MessageBoxImage image)
      {
         MessageBox.Show(message, title, MessageBoxButton.OK, image);
      }

      public MessageBoxResult Show(string message, string title, MessageBoxButton buttons, MessageBoxImage image)
      {
         return MessageBox.Show(message, title, buttons, image);
      }
   }
}