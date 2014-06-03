using Mvc.Mailer;

namespace MvcChipRequest.Mailers
{
    public class DriverMailer : MailerBase, IDriverMailer
    {
        public DriverMailer()
        {
            MasterName = "_Layout";
        }

        public virtual MvcMailMessage DeliveryDriver()
        {
            ViewBag.IDF = "123456";
            ViewBag.PMPA = "jmorriss@qti.qualcomm.com, peisan@qti.qualcomm.com";
            return Populate(x =>
            {
                x.Subject = "Driver MSM Alert Pickup for IDF# " + ViewBag.IDF;
                x.ViewName = "DeliveryDriver";
                x.To.Add("DriverMSMalert@qualcomm.com");
                x.To.Add(ViewBag.PMPA);
                x.CC.Add("qct.materials@qti.qualcomm.com");
                x.CC.Add("rcv.team@qualcomm.com");
                x.CC.Add("qct.planners@qualcomm.com");
                x.CC.Add("dept1964.pa@qti.qualcomm.com");
            });
        }
    }
}