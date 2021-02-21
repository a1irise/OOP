using System;
using System.Collections.Generic;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Entities
{
    public class SprintReport : IEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public Employee Author { get; set; }
        public List<DailyReport> DailyReports { get; set; } = new List<DailyReport>();
        public ReportState State { get; set; } = ReportState.Open;

        public enum ReportState
        {
            Open,
            Closed
        }
    }
}