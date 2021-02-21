using System;
using System.Collections.Generic;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Entities
{
    public class Employee : IEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public Employee Supervisor { get; set; } = null;
        public List<Employee> Subordinates { get; set; } = new List<Employee>();
    }
}