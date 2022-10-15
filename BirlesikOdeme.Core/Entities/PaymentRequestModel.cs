using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities
{
    public class PaymentRequestModel: BasePaymentModel
    {
        public string cardNumber { get; set; }
        public string expiryDateMonth { get; set; }
        public string expiryDateYear { get; set; }
        public string installementCount { get; set; }
        public string currency { get; set; }
        public string hash { get; set; }
        public string product { get; set; }
        public string amount { get; set; }
        public string productName { get; set; }
        public string commissionRate { get; set; } = "10.00";//Örneğin, %10 komisyon alınacaksa, 10.00 olarak gönderilmelidir.

    }
   
}
