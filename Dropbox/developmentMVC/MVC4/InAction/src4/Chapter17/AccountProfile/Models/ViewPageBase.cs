using System.Web.Mvc;

namespace AccountProfile.Models
{
public abstract class ViewPageBase<TModel> : WebViewPage<TModel>
{
    public ParamBuilder Param { get { return new ParamBuilder(); } }
}

public abstract class ViewPageBase : WebViewPage
{
    public ParamBuilder Param { get { return new ParamBuilder(); } }
}
}