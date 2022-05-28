using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiuroPracy.BusinessLogic.ModelDTO
{
    [Serializable]
   public class EmployeeDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surename { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int ContractId { get; set; }
        public int ProfessionId { get; set; }
        public int LocationId { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
    }
}
