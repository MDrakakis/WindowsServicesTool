using System;
using System.Reflection;
using System.ServiceProcess;
using System.Windows;
using System.Windows.Media;
using Serilog;
using Serilog.Events;

namespace WindowsServicesTool
{
  
  public partial class MainWindow : Window
  {
    #region Public Properties

    private static readonly string serviceToStop = ProcessHelper.ServiceToStop();
    private readonly ServiceController service = ProcessHelper.Service(serviceToStop);

    #endregion Public Properties

    public MainWindow()
    {
      InitializeComponent();

      #region Logger

      Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File($"{Environment.CurrentDirectory}\\log.txt", LogEventLevel.Debug, rollingInterval: RollingInterval.Day).CreateLogger();

      #endregion Logger

      try
      {
        if (ProcessHelper.CheckIfServiceExist(serviceToStop))
          InitFields();
        else
        {
          Statuslbl.Content = "Service not found";
          ServiceNamelbl.Content = "Service not found";
          PIDlbl.Content = "Service not found";
        }
      }
      catch (Exception ex)
      {
        ex.Source = MethodBase.GetCurrentMethod().Name;
        Log.Error($"Source:{ex.Source}()\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}\n");
      }
    }

    #region Button Clicks

    private void StopServiceBtn_Click(object sender, RoutedEventArgs e)
    {
      if (ProcessHelper.CheckIfServiceExist(serviceToStop))
      {
        try
        {
          Commands.StopService(service);
          InitFields();
        }
        catch (Exception ex)
        {
          ex.Source = MethodBase.GetCurrentMethod().Name;
          Log.Error($"Source:{ex.Source}()\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}\n");
        }
      }
    }

    private void StartServiceBtn_Click(object sender, RoutedEventArgs e)
    {
      if (ProcessHelper.CheckIfServiceExist(serviceToStop))
      {
        try
        {
          Commands.StartService(service);
          InitFields();
        }
        catch (Exception ex)
        {
          ex.Source = MethodBase.GetCurrentMethod().Name;
          Log.Error($"Source:{ex.Source}()\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}\n");
        }
      }
    }

    #endregion Button Clicks

    #region Init

    private void InitFields()
    {
      try
      {
        if (ProcessHelper.GetServicesStatus(service).Equals(ServiceControllerStatus.Running))
          Statuslbl.Foreground = Brushes.Green;
        else if (ProcessHelper.GetServicesStatus(service).Equals(ServiceControllerStatus.Stopped))
          Statuslbl.Foreground = Brushes.Red;

        Statuslbl.Content = ProcessHelper.GetServicesStatus(service).ToString();
        ServiceNamelbl.Content = service.ServiceName.ToString();
        PIDlbl.Content = ProcessHelper.GetProcessIDByServiceName(serviceToStop).ToString();
      }
      catch (Exception ex)
      {
        ex.Source = MethodBase.GetCurrentMethod().Name;
        Log.Error($"Source:{ex.Source}()\nMessage:{ex.Message}\nStackTrace:{ex.StackTrace}\n");
      }
    }

    #endregion Init
  }
}
