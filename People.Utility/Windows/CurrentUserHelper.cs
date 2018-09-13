namespace People.Utility.Windows
{
   public class CurrentUserHelper
   {

      public static string GetCurrentUserDirectory()
      {
         return WindowsHelper.GetSystemVariable(WindowsHelper.UserProfile);
      }
   }
}