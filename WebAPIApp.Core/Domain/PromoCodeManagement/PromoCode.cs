using System;
using WebAPIApp.Core.Domain.Administration;

namespace WebAPIApp.Core.Domain.PromoCodeManagement
{
    public class PromoCode
    {
        public string Code { get; set; }

        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PartnerName { get; set; }

        public virtual Employee PartnerManager { get; set; }

        public virtual Preference Preference { get; set; }
    }
}
