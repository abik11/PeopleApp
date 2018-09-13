namespace People.Utility.Windows
{
   public class WindowsHelper
   {
      public static readonly string UserProfile = "USERPROFILE";

      public static string GetSystemVariable(string variableName)
      {
         return System.Environment.GetEnvironmentVariable(variableName);
      }
   }
}