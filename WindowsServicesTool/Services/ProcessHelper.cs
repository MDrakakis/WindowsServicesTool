using System;
using System.Configuration;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Windows;
using Serilog;
using System.Reflection;

namespace WindowsServicesTool
{
  class ProcessHelper
  {
    public static uint GetProcessIDByServiceName(string serviceName)
    {
      uint processId = 0;
      string qry = $"SELECT PROCESSID FROM WIN32_SERVICE WHERE NAME = '{serviceName}'";
      ManagementObjectSearcher searcher = new ManagementObjectSearcher(qry);

      try
      {
        foreach (ManagementObject objct in searcher.Get())
        {
          processId = (uint)objct["PROCESSID"];
        }
      }
      catch (Exception ex)
      {
        ex.Source = MethodBase.GetCurrentMethod().Name;
        Log.Error($"Source:{ex.Source}()\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}\n");
      }

      return processId;
    }

    public static ServiceControllerStatus GetServicesStatus(ServiceController service)
    {
      ServiceControllerStatus serviceStatus = ServiceControllerStatus.Running;

      try
      {
        service.Refresh();

        if (service.Status.Equals(ServiceControllerStatus.Running))
        {
          serviceStatus = ServiceControllerStatus.Running;
        }
        else if (service.Status.Equals(ServiceControllerStatus.Stopped))
        {
          serviceStatus = ServiceControllerStatus.Stopped;
        }

      }
      catch (Exception ex)
      {
        ex.Source = MethodBase.GetCurrentMethod().Name;
        Log.Error($"Source:{ex.Source}()\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}\n");
      }

      return serviceStatus;
    }

    public static string ServiceToStop()
    {
      string serviceToStop = string.Empty;
      if (!string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ServiceToStop"]))
        serviceToStop = ConfigurationManager.AppSettings["ServiceToStop"];
      else
      {
        MessageBox.Show("Key Value on the App.config not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        Log.Warning("Key Value on the App.config not found.");
        Environment.Exit(-1);
      }
      return serviceToStop;
    }

    public static ServiceController Service(string ServiceToStop)
    {
      ServiceController service = new ServiceController();
      try
      {
        service = ServiceController.GetServices().Where(a => a.ServiceName == ServiceToStop).FirstOrDefault();
      }
      catch (Exception ex)
      {
        ex.Source = MethodBase.GetCurrentMethod().Name;
        Log.Error($"Source:{ex.Source}()\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}\n");
      }

      return service;
    }

    public static bool CheckIfServiceExist(string ServiceToStop)
    {
      ServiceController[] services = ServiceController.GetServices(Environment.MachineName);
      ServiceController service = services.FirstOrDefault(s => s.ServiceName == ServiceToStop);

      return service != null;
    }
  }
}
