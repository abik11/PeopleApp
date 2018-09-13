using NLog;
using System;

namespace People.Utility.Logger
{
   public class NLogProvider : ILoggerProvider
   {
      private readonly NLog.Logger log;

      public NLogProvider(Type type)
      {
         log = LogManager.GetCurrentClassLogger(type);
      }

      public void Debug(string message)
      {
         log.Debug(message);
      }

      public void Trace(string message)
      {
         log.Trace(message);
      }

      public void Info(string message)
      {
         log.Info(message);
      }

      public void Warn(string message)
      {
         log.Warn(message);
      }

      public void Error(string message)
      {
         log.Error(message);
      }

      public void Fatal(string message)
      {
         log.Fatal(message);
      }
   }
}