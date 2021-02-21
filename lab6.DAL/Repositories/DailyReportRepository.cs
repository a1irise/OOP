using System;
using System.Collections.Generic;
using System.Linq;
using lab6.DAL.Entities;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Repositories
{
    public class DailyReportRepository : IRepository<DailyReport>
    {
        private List<DailyReport> _reports;

        public DailyReportRepository()
        {
            _reports = new List<DailyReport>();
        }

        public IEnumerable<DailyReport> GetAll()
        {
            return _reports;
        }

        public DailyReport Get(string id)
        {
            return Find(r => r.Id == id).First();
        }

        public void Create(DailyReport item)
        {
            _reports.Add(item);
        }

        public void Update(DailyReport item)
        {
            var report = Find(r => r.Id == item.Id).First();
            report = item;
            Delete(item.Id);
            Create(report);
        }

        public void Delete(string id)
        {
            _reports.Remove(Find(w => w.Id == id).First());
        }

        public IEnumerable<DailyReport> Find(Func<DailyReport, bool> predicate)
        {
            var ret = new List<DailyReport>();
            foreach (var report in _reports)
                if (predicate(report))
                    ret.Add(report);
            return ret;
        }
    }
}