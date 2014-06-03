using System.Web;
using System.Data;

public class PDSADataCommon
{
  #region Common Methods
  public static DataSet FileToDataSet(string fileName)
  {
    DataSet ds = null;

    ds = new DataSet();

    ds.ReadXml(fileName);

    return ds;
  }

  public static DataSet GetCountries()
  {
    return FileToDataSet(HttpContext.Current.Server.MapPath("~/XML-Common/Countries.xml"));
  }

  public static DataSet GetUSStates()
  {
    return FileToDataSet(HttpContext.Current.Server.MapPath("~/XML-Common/USStates.xml"));
  }

  public static DataSet GetCanadianProvinces()
  {
    return FileToDataSet(HttpContext.Current.Server.MapPath("~/XML-Common/CanadianProvinces.xml"));
  }

  #endregion
}