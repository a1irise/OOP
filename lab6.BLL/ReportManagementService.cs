using System;
using System.Collections.Generic;
using lab6.BLL.Infostructure;
using lab6.DAL.Entities;
using lab6.DAL.Infostructure;
using lab6.DAL.Repositories;

namespace lab6.BLL
{
    public class ReportManagementService : IReportManagementService
    {
        private readonly IRepository<DailyReport> _dailyRepo;
        private readonly IRepository<SprintReport> _sprintRepo;
        private readonly IRepository<TeamReport> _teamRepo;

        public ReportManagementService()
        {
            _dailyRepo = new DailyReportRepository();
            _sprintRepo = new SprintReportRepository();
            _teamRepo = new TeamReportRepository();
        }

        public DailyReport CreateDailyReport(Employee employee)
        {
            var report = new DailyReport
            {
                CreationTime = DateTime.Now,
                Author = employee,
                Tasks = new List<Task>(),
                State = DailyReport.ReportState.Open
            };
            _dailyRepo.Create(report);
            return report;
        }

        public void EditDailyReport(DailyReport report)
        {
            _dailyRepo.Update(report);
        }

        public void SaveDailyReport(DailyReport report)
        {
            report.State = DailyReport.ReportState.Closed;
            _dailyRepo.Update(report);
        }

        public SprintReport CreateSprintReport(Employee employee)
        {
            var report = new SprintReport
            {
                CreationTime = DateTime.Now,
                Author = employee,
                DailyReports = new List<DailyReport>(),
                State = SprintReport.ReportState.Open
            };
            _sprintRepo.Create(report);
            return report;
        }

        public void EditSprintReport(SprintReport report)
        {
            _sprintRepo.Update(report);
        }

        public void SaveSprintReport(SprintReport report)
        {
            report.State = SprintReport.ReportState.Closed;
            _sprintRepo.Update(report);
        }

        public TeamReport CreateTeamReport(Employee employee)
        {
            var report = new TeamReport
            {
                CreationTime = DateTime.Now,
                Author = employee,
                SprintReports = new List<SprintReport>(),
                State = TeamReport.ReportState.Open
            };
            _teamRepo.Create(report);
            return report;
        }

        public void EditTeamReport(TeamReport report)
        {
            _teamRepo.Update(report);
        }

        public void SaveTeamReport(TeamReport report)
        {
            report.State = TeamReport.ReportState.Closed;
            _teamRepo.Update(report);
        }
    }
}