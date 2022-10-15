using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities.Payment
{
    public class PaymentResponseModel
    {
        public bool Fail { get; set; }
        public int StatusCode { get; set; }
        public PaymentResponseResultModel result { get; set; }

    }

    public class PaymentResponseResultModel
    {
        public int ResponseCode { get; set; }
        public string responseMessage { get; set; }
        public string orderId { get; set; }
        public string txnType { get; set; }
        public string txnStatus { get; set; }
        public int vposId { get; set; }
        public string vposName { get; set; }
        public string authCode { get; set; }
        public string hostReference { get; set; }
        public string totalAmount { get; set; }

    }
}
