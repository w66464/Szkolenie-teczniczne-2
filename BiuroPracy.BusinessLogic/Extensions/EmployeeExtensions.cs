using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiuroPracy.BusinessLogic.ModelDTO;
using BiuroPracy.Domain;

namespace BiuroPracy.BusinessLogic.Extensions
{
   public static class EmployeeExtensions
    {
        public static Employee ToEmployee(this EmployeeDto dto)
        {
            if (dto == null)
                return null;

            return new Employee
            {
               Name = dto.Name,
               Email = dto.Email,
               Surname = dto.Surename,
               Password = dto.Password,
               Profession = dto.ProfessionId > 0? new Profession() { Id = dto.ProfessionId } : null,
                Contract = dto.ContractId >0 ?new Contract() { Id = dto.ContractId }:null,
               Location = new Location()
               {
                   City = dto.CityId>0 ? new City() {Id = dto.CityId}:null,
                   Country = dto.CountryId > 0 ? new Country() { Id = dto.CountryId } : null,
                   Street = dto.Street,
                   PostalCode = dto.PostalCode
               },
            };

        }
    }
}
