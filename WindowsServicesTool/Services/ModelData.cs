using System.ComponentModel;

namespace WindowsServicesTool
{
  class ModelData : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    #region Private Variables

    private string _PID;
    private string _CurrentStatus;
    private string _CurrentName;

    private string _Name;
    private string _Status;

    #endregion Private Variables

    #region Public Variables

    public string PID
    {
      get { return _PID; }
      set
      {
        if (_PID != value)
        {
          _PID = value;
          PropertyChanged(this, new PropertyChangedEventArgs(PID));
        }
      }
    }

    public string CurrentStatus
    {
      get { return _CurrentStatus; }
      set
      {
        if (_CurrentStatus != value)
        {
          _CurrentStatus = value;
          PropertyChanged(this, new PropertyChangedEventArgs(CurrentStatus));
        }
      }
    }

    public string CurrentName
    {
      get { return _CurrentName; }
      set
      {
        if (_CurrentName != value)
        {
          _CurrentName = value;
          PropertyChanged(this, new PropertyChangedEventArgs(CurrentName));
        }
      }
    }

    public string Name
    {
      get { return _Name; }
      set
      {
        if (_Name != value)
        {
          _Name = value;
          PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
      }
    }

    public string Status
    {
      get { return _Status; }
      set
      {
        if (_Status != value)
        {
          _Status = value;
          PropertyChanged(this, new PropertyChangedEventArgs(Status));
        }
      }
    }

    #endregion Public Variables
  }
}
