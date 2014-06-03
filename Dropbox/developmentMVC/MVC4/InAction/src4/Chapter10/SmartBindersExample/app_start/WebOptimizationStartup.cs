using System.Web.Optimization;
 
[assembly: WebActivator.PostApplicationStartMethod(
typeof(SmartBindersExample.App_Start.WebOptimizationStartup), "Start")]
 
namespace SmartBindersExample.App_Start {
public static class WebOptimizationStartup {
		public static void Start(){
	            BundleTable.Bundles.RegisterTemplateBundles();
		
		}
	}
}

