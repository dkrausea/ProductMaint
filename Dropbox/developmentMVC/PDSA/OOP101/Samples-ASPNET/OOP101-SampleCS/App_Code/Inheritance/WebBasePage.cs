using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public class WebBasePage : System.Web.UI.Page
{
  private bool mUserTrack = false;

  protected bool UserTrack
  {
    get { return mUserTrack; }
    set { mUserTrack = value; }
  }

  protected override void OnLoad(System.EventArgs e)
  {
    //  Do something before

    //  Set Default value for UserTrack Property
    mUserTrack = Convert.ToBoolean(ConfigurationManager.AppSettings["UserTrack"]);


    //  Call Page Event
    base.OnLoad(e);


    //  Do something After

    //  Check UserTrack property
    //  User could change it in Page_Load()
    if (mUserTrack)
    {
      //  Call TrackUsers method
    }
  }

  protected override void OnPreInit(System.EventArgs e)
  {
    //  Try moving this after the MyBase.OnPreInit() call
    this.Theme = ConfigurationManager.AppSettings["Theme"];

    base.OnPreInit(e);
  }
}