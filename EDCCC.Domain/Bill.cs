﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDCCC.Domain
{
    public class Bill : BaseDomainModel
    {
        public string Description { get; set; }

        public double Amount { get; set; }

        public int CCardId { get; set; }    

        public virtual CCard CCards { get; set; }
    }
}
