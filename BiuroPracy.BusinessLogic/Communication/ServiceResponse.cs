﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiuroPracy.BusinessLogic.Communication
{
   public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Errors { get; set; }

        public ServiceResponse()
        {
            Success = true;

        }
    }
}
