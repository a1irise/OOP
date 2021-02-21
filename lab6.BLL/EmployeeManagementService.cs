using System.Collections.Generic;
using lab6.BLL.Infostructure;
using lab6.DAL.Entities;
using lab6.DAL.Infostructure;
using lab6.DAL.Repositories;

namespace lab6.BLL
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        private IRepository<Employee> _repo;

        public EmployeeManagementService()
        {
            _repo = new EmployeeRepository();
        }

        public void AddEmployee(Employee employee)
        {
            _repo.Create(employee);
        }

        public void ChangeSupervisor(Employee employee, Employee supervisor)
        {
            if (employee.Supervisor != null)
            {
                employee.Supervisor.Subordinates.Remove(employee);
                _repo.Update(employee.Supervisor);
            }
            employee.Supervisor = supervisor;
            _repo.Update(employee);
            supervisor.Subordinates.Add(employee);
            _repo.Update(supervisor);
        }

        public IEnumerable<Employee> GetEmployeeHierarchy()
        {
            return _repo.GetAll();
        }
    }
}