using System;
using System.Windows;

namespace OOP101_CS
{
  /// <summary>
  /// Interaction logic for frmEventSample.xaml
  /// </summary>
  public partial class frmEventSample : Window
  {
    public frmEventSample()
    {
      InitializeComponent();
    }

    #region Event Sample 1
    private EventSampler1 mEV1 = new EventSampler1();

    protected void btnSample1_Click(Object sender, RoutedEventArgs e)
    {
      mEV1.After += new EventSampler1.AfterEventHandler(mEV1_After);
      mEV1.Before += new EventSampler1.BeforeEventHandler(mEV1_Before);
      mEV1.Process();
    }

    private void mEV1_After(string Message)
    {
      lblSample1.Text = Message;
    }

    private void mEV1_Before(string Message)
    {
      lblSample1.Text = Message;
    }

    #endregion

    #region Event Sample 2
    private EventSampler2 mEV2 = new EventSampler2();

    protected void btnSample2_Click(Object sender, RoutedEventArgs e)
    {
      mEV2.After += new EventSampler2.AfterEventHandler(mEV2_After);
      mEV2.ContinueProcess += new EventSampler2.ContinueProcessEventHandler(mEV2_ContinueProcess);
      mEV2.Process();
    }

    private void mEV2_After(object sender, EventSampler2EventArgs e)
    {
      lblSample2.Text = e.Message + " - TimesThru = " + e.TimesThru.ToString();
    }

    private void mEV2_ContinueProcess(object sender, EventSampler2EventArgs e)
    {
      if (e.TimesThru == 10)
      {
        e.Cancel = true;
      }
    }
    #endregion
  }
}