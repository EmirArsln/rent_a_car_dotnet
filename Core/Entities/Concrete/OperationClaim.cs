﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class OperationClaim :IEntity
    {
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; } = string.Empty; 
    }
}
