using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Domain
{
    public class CCard : BaseDomainModel
    {
        public string CNumber { get; set; }

        public double? Limit { get; set; }
        public double InterestRate { get; set; } = 0.0;

        public DateTime DueDate { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
