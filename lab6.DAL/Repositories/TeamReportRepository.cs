using System;
using System.Collections.Generic;
using System.Linq;
using lab6.DAL.Entities;
using lab6.DAL.Infostructure;

namespace lab6.DAL.Repositories
{
    public class TeamReportRepository : IRepository<TeamReport>
    {
        private List<TeamReport> _reports;

        public TeamReportRepository()
        {
            _reports = new List<TeamReport>();
        }

        public IEnumerable<TeamReport> GetAll()
        {
            return _reports;
        }

        public TeamReport Get(string id)
        {
            return Find(r => r.Id == id).First();
        }

        public void Create(TeamReport item)
        {
            _reports.Add(item);
        }

        public void Update(TeamReport item)
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

        public IEnumerable<TeamReport> Find(Func<TeamReport, bool> predicate)
        {
            var ret = new List<TeamReport>();
            foreach (var report in _reports)
                if (predicate(report))
                    ret.Add(report);
            return ret;
        }
    }
}