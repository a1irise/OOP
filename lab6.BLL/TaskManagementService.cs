using System;
using System.Collections.Generic;
using lab6.BLL.Infostructure;
using lab6.DAL.Infostructure;
using lab6.DAL.Entities;
using lab6.DAL.Repositories;

namespace lab6.BLL
{
    public class TaskManagementService : ITaskManagementService
    {
        private IRepository<Task> _repo;

        public TaskManagementService()
        {
            _repo = new TaskRepository();
        }

        public IEnumerable<Task> IdTaskSearch(string id)
        {
            return _repo.Find(t => t.Id == id);
        }

        public IEnumerable<Task> CreationTimeTaskSearch(DateTime creationTime)
        {
            return _repo.Find(t => t.CreationTime == creationTime);
        }

        public IEnumerable<Task> LastModifiedTaskSearch(DateTime lastModified)
        {
            return _repo.Find(t => t.LastModified == lastModified);
        }

        public IEnumerable<Task> EmployeeTaskSearch(Employee employee)
        {
            return _repo.Find(t => t.Author.Id == employee.Id);
        }

        public IEnumerable<Task> SupervisorSubordinatesTasksSearch(Employee supervisor)
        {
            var ret = new List<Task>();
            foreach (var subordinate in supervisor.Subordinates)
                foreach (var task in EmployeeTaskSearch(subordinate))
                    ret.Add(task);
            return ret;
        }

        public Task CreateTask(Task task)
        {
            _repo.Create(task);
            return task;
        }

        public void EditTask(Task task)
        {
            _repo.Update(task);
        }
    }
}