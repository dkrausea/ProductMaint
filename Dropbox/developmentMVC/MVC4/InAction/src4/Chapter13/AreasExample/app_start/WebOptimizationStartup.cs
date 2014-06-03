using System.Web.Optimization;
 
[assembly: WebActivator.PostApplicationStartMethod(
typeof(AreasExample.App_Start.WebOptimizationStartup), "Start")]
 
namespace AreasExample.App_Start {
public static class WebOptimizationStartup {
		public static void Start(){
	            BundleTable.Bundles.RegisterTemplateBundles();
		
		}
	}
}

