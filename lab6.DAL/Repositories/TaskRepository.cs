using lab6.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private List<Task> _tasks;

        public TaskRepository()
        {
            _tasks = new List<Task>();
        }
        
        public IEnumerable<Task> GetAll()
        {
            return _tasks;
        }

        public Task Get(string id)
        {
            return Find(t => t.Id == id).First();
        }

        public void Create(Task item)
        {
            _tasks.Add(item);
        }

        public void Update(Task item)
        {
            var task = Find(t => t.Id == item.Id).First();
            task = item;
            Delete(item.Id);
            Create(task);
        }

        public void Delete(string id)
        {
            _tasks.Remove(Find(t => t.Id == id).First());
        }

        public IEnumerable<Task> Find(Func<Task, bool> predicate)
        {
            var ret = new List<Task>();
            foreach (var task in _tasks)
                if (predicate(task))
                    ret.Add(task);
            return ret;
        }
    }
}