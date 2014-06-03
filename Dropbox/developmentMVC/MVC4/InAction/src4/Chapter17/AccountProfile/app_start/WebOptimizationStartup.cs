using System.Web.Optimization;
 
[assembly: WebActivator.PostApplicationStartMethod(
typeof(AccountProfile.App_Start.WebOptimizationStartup), "Start")]
 
namespace AccountProfile.App_Start {
public static class WebOptimizationStartup {
		public static void Start(){
	            BundleTable.Bundles.RegisterTemplateBundles();
		
		}
	}
}

