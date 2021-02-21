using lab6.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee Get(string id)
        {
            return Find(w => w.Id == id).First();
        }

        public void Create(Employee item)
        {
            _employees.Add(item);
        }

        public void Update(Employee item)
        {
            var employee = Find(w => w.Id == item.Id).First();
            employee = item;
            Delete(item.Id);
            Create(employee);
        }

        public void Delete(string id)
        {
            _employees.Remove(Find(w => w.Id == id).First());
        }

        public IEnumerable<Employee> Find(Func<Employee, bool> predicate)
        {
            var ret = new List<Employee>();
            foreach (var task in _employees)
                if (predicate(task))
                    ret.Add(task);
            return ret;
        }
    }
}