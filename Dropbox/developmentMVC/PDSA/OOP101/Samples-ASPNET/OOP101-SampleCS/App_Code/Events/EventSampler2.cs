using System;

public class EventSampler2
{
  public delegate void BeforeEventHandler(object sender, EventSampler2EventArgs e);
  public event BeforeEventHandler Before;
  public delegate void ContinueProcessEventHandler(object sender, EventSampler2EventArgs e);
  public event ContinueProcessEventHandler ContinueProcess;
  public delegate void AfterEventHandler(object sender, EventSampler2EventArgs e);
  public event AfterEventHandler After;

  public int TimesThru = 0;

  public void Process()
  {
    EventSampler2EventArgs ev = new EventSampler2EventArgs();

    ev.Message = "Before the Process";
    if (null != Before) 
      Before(this, ev);

    for (TimesThru = 1; TimesThru <= 10000000; TimesThru++)
    {
      ev.TimesThru = TimesThru;
      if (null != ContinueProcess) ContinueProcess(this, ev);

      if (ev.Cancel)
      {
        break;
      }
    }

    ev.Message = "After the Process";
    if (null != After) 
      After(this, ev);
  }
}

public class EventSampler2EventArgs : EventArgs
{
  public EventSampler2EventArgs()
  {
    Message = string.Empty;
    Cancel = false;
    TimesThru = 0;
  }

  public string Message { get; set; }
  public bool Cancel { get; set; }
  public int TimesThru { get; set; }
}