using System.Web.Optimization;
 
[assembly: WebActivator.PostApplicationStartMethod(
typeof(UITesting.App_Start.WebOptimizationStartup), "Start")]
 
namespace UITesting.App_Start {
public static class WebOptimizationStartup {
		public static void Start(){
	            BundleTable.Bundles.RegisterTemplateBundles();
		
		}
	}
}

