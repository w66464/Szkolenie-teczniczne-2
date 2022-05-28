using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiuroPracy.BusinessLogic.ModelDTO;

namespace BiuroPracy.BusinessLogic.Communication
{
    public class EmployeeServiceResponse : ServiceResponse
    {
        public EmployeeDto Data { get; set; }
    }
}
