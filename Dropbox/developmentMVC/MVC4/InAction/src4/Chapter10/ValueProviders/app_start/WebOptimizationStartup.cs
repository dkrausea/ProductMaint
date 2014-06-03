using System.Web.Optimization;
 
[assembly: WebActivator.PostApplicationStartMethod(
typeof(ValueProvidersExample.App_Start.WebOptimizationStartup), "Start")]
 
namespace ValueProvidersExample.App_Start {
public static class WebOptimizationStartup {
		public static void Start(){
	            BundleTable.Bundles.RegisterTemplateBundles();
		
		}
	}
}

