using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities
{
    /// <summary>
    /// dokümanlara ve maildeki verileri direkt yazdım.
    /// </summary>
    public class PaymentHash : BasePaymentModel
    {
        public string HashPassword { get; set; } = "kU8@iP3@";
        public string OkUrl { get; set; } = "bulamadım";
        public string FailUrl { get; set; } = "bulamadım";

    }
}
