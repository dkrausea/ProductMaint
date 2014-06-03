using System.Web.Optimization;
 
[assembly: WebActivator.PostApplicationStartMethod(
typeof(SparkExample.App_Start.WebOptimizationStartup), "Start")]
 
namespace SparkExample.App_Start {
public static class WebOptimizationStartup {
		public static void Start(){
	            BundleTable.Bundles.RegisterTemplateBundles();
		
		}
	}
}

