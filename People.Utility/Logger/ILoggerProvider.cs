namespace People.Utility.Logger
{
   interface ILoggerProvider
   {
      void Debug(string message);
      void Trace(string message);
      void Info(string message);
      void Warn(string message);
      void Error(string message);
      void Fatal(string message);
   }
}