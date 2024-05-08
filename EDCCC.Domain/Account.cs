using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Domain
{
    public class Account : BaseDomainModel
    {
        public int Number { set; get; }
        public int? TypeAccountId { set; get; }
        public virtual TypeAccount? TypeAccount { set; get; }

        public int? CustomerId { set; get; }

        public virtual Customers? Customer { set; get; }

       
    }
}
