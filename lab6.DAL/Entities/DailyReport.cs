using System;
using System.Collections.Generic;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Entities
{
    public class DailyReport : IEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public Employee Author { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
        public ReportState State { get; set; } = ReportState.Open;

        public enum ReportState
        {
            Open,
            Closed
        }
    }
}