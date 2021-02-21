using System.Collections.Generic;
using lab6.DAL.Entities;

namespace lab6.BLL.Infostructure
{
    public interface IEmployeeManagementService
    {
        public void AddEmployee(Employee employee);
        public void ChangeSupervisor(Employee employee, Employee supervisor);
        public IEnumerable<Employee> GetEmployeeHierarchy();
    }
}