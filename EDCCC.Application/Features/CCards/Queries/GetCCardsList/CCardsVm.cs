using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Application.Features.CCards.Queries.GetCCardsList
{
    public class CCardsVm
    {
       

        public int Id { get; set; }
        public string? CNumber { get; set; }

        public double? Limit { get; set; }
        public double InterestRate { get; set; } = 0.0;

        public DateTime DueDate { get; set; }
        public int AccountId { get; set; }


      

    }
}
