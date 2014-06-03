using System.Web.Optimization;
 
[assembly: WebActivator.PostApplicationStartMethod(
typeof(Guestbook.App_Start.WebOptimizationStartup), "Start")]
 
namespace Guestbook.App_Start {
public static class WebOptimizationStartup {
		public static void Start(){
	            BundleTable.Bundles.RegisterTemplateBundles();
		
		}
	}
}

