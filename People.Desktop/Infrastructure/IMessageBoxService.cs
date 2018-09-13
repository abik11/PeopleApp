using System.Windows;

namespace People.Desktop.Infrastructure
{
   public interface IMessageBoxService
   {
      void Show(string message, string title);
      void Show(string message, string title, MessageBoxImage image);
      MessageBoxResult Show(string message, string title, MessageBoxButton buttons, MessageBoxImage image);
   }
}