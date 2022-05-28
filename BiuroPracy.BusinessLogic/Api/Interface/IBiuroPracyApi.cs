using BiuroPracy.BusinessLogic.Communication;
using BiuroPracy.BusinessLogic.ModelDTO;

namespace BiuroPracy.BusinessLogic.Api.Interface
{
    public interface IBiuroPracyApi
    {
        void TestNHibernate();

        /// <summary>
        /// Metoda pobierająca dane z tabeli Profession
        /// </summary>
        /// <returns>zwraca listę Id Name  z tabeli Profession</returns>
        ListIdNamePairServiceResponse GetProfessions();

        /// <summary>
        /// Metoda dodaje nowego pracownika do bazy danych
        /// </summary>
        /// <returns>zwraca inforację czy podczas zapisu danych nie wystąpił błąd</returns>
        ServiceResponse AddEmployee(EmployeeDto employee);

        /// <summary>
        /// Metoda pobiera dane pracowników
        /// </summary>
        /// <returns>zwraca listę pracowników</returns>
        EmployeesServiceResponse GetEmployees();

    }
}