using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Events_EventSample : System.Web.UI.Page
{
  #region Event Sample 1
  private EventSampler1 mEV1 = new EventSampler1();

  protected void btnSample1_Click(System.Object sender, System.EventArgs e)
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

  protected void btnSample2_Click(System.Object sender, System.EventArgs e)
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