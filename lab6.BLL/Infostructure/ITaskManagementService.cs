using System;
using System.Collections.Generic;
using lab6.DAL.Entities;

namespace lab6.BLL.Infostructure
{
    public interface ITaskManagementService
    {
        public IEnumerable<Task> IdTaskSearch(string id);
        public IEnumerable<Task> CreationTimeTaskSearch(DateTime creationTime);
        public IEnumerable<Task> LastModifiedTaskSearch(DateTime lastModified);
        public IEnumerable<Task> EmployeeTaskSearch(Employee employee);
        public IEnumerable<Task> SupervisorSubordinatesTasksSearch(Employee supervisor);

        public Task CreateTask(Task task);
        public void EditTask(Task task);
    }
}