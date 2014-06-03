public class EventSampler1
{
  public delegate void BeforeEventHandler(string message);
  public event BeforeEventHandler Before;
  public delegate void AfterEventHandler(string message);
  public event AfterEventHandler After;

  public void Process()
  {
    if (null != Before)
      Before("Before the Process");

    for (int index = 1; index <= 10000000; index++)
    {

    }

    if (null != After) 
      After("After the Process");
  }
}