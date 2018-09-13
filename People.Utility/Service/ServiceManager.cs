using System;
using System.ServiceModel;

namespace People.Utility.Service
{
   // Many thanks to Adrian Walkiewicz for this amazing class!
   public class ServiceManager<T> : IDisposable where T : ICommunicationObject, new()
   {
      private Action<Exception> _exceptionAction;
      private bool _isDisposed;

      public T Client { get; private set; }

      public ServiceManager() : this(null)
      { }

      public ServiceManager(Action<Exception> exceptionAction)
      {
         Client = new T();
         _exceptionAction = exceptionAction;
      }

      private void CloseService()
      {
         if (Client != null)
         {
            try
            {
               Client?.Close();
            }
            catch (CommunicationException e)
            {
               Client.Abort();
               _exceptionAction?.Invoke(e);
            }
            catch (TimeoutException e)
            {
               Client.Abort();
               _exceptionAction?.Invoke(e);
            }
            catch (Exception e)
            {
               Client.Abort();
               _exceptionAction?.Invoke(e);
               throw;
            }
         }
      }

      public void Dispose()
      {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      protected virtual void Dispose(bool disposing)
      {
         if (!_isDisposed)
         {
            if (disposing)
            {
               // dispose managed resources that implement IDisposable
               CloseService();
            }
            // dispose unmanaged resources
            _isDisposed = true;
         }
      }

      ~ServiceManager()
      {
         Dispose(false);
      }
   }
}