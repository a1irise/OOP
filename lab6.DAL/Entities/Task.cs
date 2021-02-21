using System;
using System.Collections.Generic;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Entities
{
    public class Task : IEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public int Title { get; set; }
        public string Description { get; set; }
        public Employee Author { get; set; }
        public TaskState State { get; set; } = TaskState.Open;
        public List<string> Comments { get; set; } = new List<string>();
        public DateTime LastModified { get; set; } = DateTime.Now;
        
        public enum TaskState
        {
            Open,
            Active,
            Resolved
        }
    }
}