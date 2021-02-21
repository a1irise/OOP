using System;
using System.Collections.Generic;
using System.Linq;
using lab6.DAL.Entities;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Repositories
{
    public class SprintReportRepository : IRepository<SprintReport>
    {
        private List<SprintReport> _reports;

        public SprintReportRepository()
        {
            _reports = new List<SprintReport>();
        }

        public IEnumerable<SprintReport> GetAll()
        {
            return _reports;
        }

        public SprintReport Get(string id)
        {
            return Find(r => r.Id == id).First();
        }

        public void Create(SprintReport item)
        {
            _reports.Add(item);
        }

        public void Update(SprintReport item)
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

        public IEnumerable<SprintReport> Find(Func<SprintReport, bool> predicate)
        {
            var ret = new List<SprintReport>();
            foreach (var report in _reports)
                if (predicate(report))
                    ret.Add(report);
            return ret;
        }
    }
}