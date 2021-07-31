using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpDemo.Models
{

    public class BillDetails
    {

        public string issuerAgencyId { get; set; }

        public string billingAccountId { get; set; }

        public string billingCycle { get; set; }

        public string dueAmount { get; set; }

        public string paidAmount { get; set; }

        public string billReferenceInfo { get; set; }

        public string agencyCode { get; set; }

        public BillDetails()
        {

        }

        public BillDetails(string issuerAgencyId, string billingAccountId, string billingCycle, string dueAmount, string paidAmount, string billReferenceInfo, string agencyCode)
        {
            this.issuerAgencyId = issuerAgencyId;
            this.billingAccountId = billingAccountId;
            this.billingCycle = billingCycle;
            this.dueAmount = dueAmount;
            this.paidAmount = paidAmount;
            this.billReferenceInfo = billReferenceInfo;
            this.agencyCode = agencyCode;
        }

        public override string ToString()
        {
            return "{\"issuerAgencyId\":\"" + issuerAgencyId +"\""+
                ",\"billingAccountId\":\"" + billingAccountId + "\"" +
                ",\"billingCycle\":\"" + billingCycle + "\"" +
                ",\"dueAmount\":\"" + dueAmount + "\"" +
                ",\"paidAmount\":\"" + paidAmount + "\"" +
                ",\"billReferenceInfo\":\"" + billReferenceInfo + "\"" +
                ",\"agencyCode\":\"" + agencyCode + "\"" + "}";
        }
    }
}