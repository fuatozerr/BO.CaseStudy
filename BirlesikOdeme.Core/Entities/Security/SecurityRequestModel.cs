using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirlesikOdeme.Core.Entities.Security
{
    public class SecurityRequestModel
    {
        //verileri configede yazabilirdim. farklılık olsun istedim :)
        public string ApiKey { get; set; } = "kU8@iP3@";
        public string Email { get; set; } = "murat.karayilan@dotto.com.tr";
        public string Lang { get; set; } = "TR";
    }
}
