using System;
using System.Collections;
using System.Linq;
using BiuroPracy.BusinessLogic.Api.Interface;
using BiuroPracy.BusinessLogic.Communication;
using BiuroPracy.BusinessLogic.Extensions;
using BiuroPracy.BusinessLogic.Logic;
using BiuroPracy.BusinessLogic.ModelDTO;
using BiuroPracy.BusinessLogic.NHibernate;
using BiuroPracy.Domain;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;

namespace BiuroPracy.BusinessLogic.Api
{
    public class BiuroPracyApi : BaseApi, IBiuroPracyApi
    {

        public void TestNHibernate()
        {
            
                using (var session = NHibernateBase.Session) //tworzymy obiekt połączenie do bazy danych
                {
                    using (var transaction = session.BeginTransaction())//tworzymy obiekt tranzakcji 
                    {
                        try
                        {
                        var proffesion= session.Get<Profession>(1); //pobieramy z bazy danych z tabeli Profession rekord o ID 1   
                            UpdateEmployee(session);
                      // var id =  AddEmployee( session);
                      // GetEmployee(session);
                        transaction.Commit();
                        }
                        catch (Exception e)
                        {
                        transaction.Rollback();
                            
                        }
                }
                }
           
           
        }

        public ListIdNamePairServiceResponse GetProfessions()
        {
            try
            {
                using (var session = NHibernateBase.Session) //tworzymy obiekt połączenie do bazy danych
                {
                    var proffesions = session.Query<Profession>()
                        .Select(x =>
                            new IdNamePair
                            {
                                Id = x.Id,
                                Name = x.Name
                            }).ToList();
                    return new ListIdNamePairServiceResponse()
                    {
                        Data = proffesions
                    };
                }
            }
            catch (Exception e)
            {
                return new ListIdNamePairServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }

        public ServiceResponse AddEmployee(EmployeeDto employee)
        {

            using (var session = NHibernateBase.Session) //tworzymy obiekt połączenie do bazy danych
            {
                using (var transaction = session.BeginTransaction()) //tworzymy obiekt tranzakcji 
                {
                    try
                    {
                        var employeeAdd = employee.ToEmployee();
                        session.Save(employeeAdd);
                        transaction.Commit();
                        var email = new  EmailManager();
                        email.SendEmail("Dodano pracownika", "hasło: " + employeeAdd.Password, employeeAdd.Email);
                    }

                    catch (Exception e)
                    {
                        transaction.Rollback();
                        return new ServiceResponse()
                        {
                            Errors = e.StackTrace + " " + e.Message,
                            Success = false
                        };
                    }
                }
            }
                return new ServiceResponse();
           
        }

        public EmployeesServiceResponse GetEmployees()
        {
            try
            {
                using (var session = NHibernateBase.Session) 
                {
                    var employees = session.Query<Employee>()
                        .Select(x =>
                            new EmployeeDto()
                            {
                                 Email =  x.Email,
                                 Name = x.Name,
                                 Surename = x.Surname,
                               DateOfBirth  = x.DateOfBirth,
                               Id =  x.Id
                            }).ToList();
                    return new EmployeesServiceResponse()
                    {
                        Data = employees
                    };
                }
            }
            catch (Exception e)
            {
                return new EmployeesServiceResponse()
                {
                    Errors = e.StackTrace + " " + e.Message,
                    Success = false
                };
            }
        }

        private void GetEmployee(ISession session)
        {
            var employee = session.Get<Employee>(3); // method get by primary key
            
            var employee1 = session.Query<Employee>()//LINQ TO NHIBERNATE
                .Where(x => x.Name == "Łukasz" && x.Location != null
                            && x.Location.City.Name == "Warszawa")
                            .Select(x => new { Name = x.Surname }).ToList();


            var employee2 = session.CreateSQLQuery(@"SELECT Id, Name, Surname" +
                                                   "  FROM Employee WHERE Name = :name")
                .SetParameter("name", "Łukasz")
                .SetResultTransformer(Transformers.AliasToEntityMap)
                .List<IDictionary>();
        }


        private void UpdateEmployee(ISession session)
        {
            var employee = session.Get<Employee>(3);
            employee.Name = "WWWWWWWWWWWWWWWWWWWWWWWWW"
                ;            employee.Location = new Location()
            {
                City = new City() {Id = 1},
                Country = new Country() {Id = 1},
                PostalCode = "25-222",
                Street = "WWWW 12/30"
            };
                    session.Update(employee);
        }
        private int AddEmployee(ISession session)
        {
          
            var employee = new Employee()
            {
                Email = "lukasz@wp.pl",
                DateOfBirth = DateTime.Now.AddYears(-18),
                Password = "1234",
                Contract = new Contract() {Id = 1},
                Profession = new Profession() {Id = 1},
                Name = "Łukasz",
                Surname = "Piechocki",
                Location = new Location()
                {
                    City = new City() { Id = 1},
                    Country = new Country() { Id = 1 },
                    PostalCode = "25-222",
                    Street = "Mikołajczyka 12/30"
                }

            };
            return (int)session.Save(employee);
        }
    }
}