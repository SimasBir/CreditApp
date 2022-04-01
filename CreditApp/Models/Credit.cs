using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditApp.Models
{
    public class Credit
    {
        public decimal Amount { get; set; }
        public int Term { get; set; }
        public decimal CurrentAmount { get; set; }
    }
}
