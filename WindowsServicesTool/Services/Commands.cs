using System.ServiceProcess;
using Serilog;
using System;
using System.Reflection;

namespace WindowsServicesTool
{
  class Commands
  {
    #region Service Commands

    public static void StartService(ServiceController service)
    {
      if (ProcessHelper.GetServicesStatus(service).Equals(ServiceControllerStatus.Stopped))
      {
        try
        {
          service.Start();
          service.WaitForStatus(ServiceControllerStatus.Running);
        }
        catch (Exception ex)
        {
          ex.Source = MethodBase.GetCurrentMethod().Name;
          Log.Error($"Source:{ex.Source}()\n\nMessage:{ex.Message}\n\nStackTrace:{ex.StackTrace}");
        }
      }
    }

    public static void StopService(ServiceController service)
    {
      if (ProcessHelper.GetServicesStatus(service).Equals(ServiceControllerStatus.Running))
      {
        try
        {
          service.Stop();
          service.WaitForStatus(ServiceControllerStatus.Stopped);
        }
        catch (Exception ex)
        {
          ex.Source = MethodBase.GetCurrentMethod().Name;
          Log.Error($"Source:{ex.Source}()\n\nMessage:{ex.Message}\n\nStackTrace:{ex.StackTrace}");
        }
      }
    }

    #endregion Service Commands
  }
}
