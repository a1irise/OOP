using lab6.DAL.Entities;

namespace lab6.BLL.Infostructure
{
    public interface IReportManagementService
    {
        public DailyReport CreateDailyReport(Employee employee);
        public void EditDailyReport(DailyReport report);
        public void SaveDailyReport(DailyReport report);

        public SprintReport CreateSprintReport(Employee employee);
        public void EditSprintReport(SprintReport report);
        public void SaveSprintReport(SprintReport report);

        public TeamReport CreateTeamReport(Employee employee);
        public void EditTeamReport(TeamReport report);
        public void SaveTeamReport(TeamReport report);
    }
}