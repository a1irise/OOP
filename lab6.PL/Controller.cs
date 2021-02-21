using System;
using System.Collections.Generic;
using lab6.BLL;
using lab6.BLL.Infostructure;
using lab6.DAL.Entities;

namespace lab6.PL
{
    public class Controller
    {
        private readonly IEmployeeManagementService _employeeManagementService;
        private readonly ITaskManagementService _taskManagementService;
        private readonly IReportManagementService _reportManagementService;

        public Controller()
        {
            _employeeManagementService = new EmployeeManagementService();
            _taskManagementService = new TaskManagementService();
            _reportManagementService = new ReportManagementService();
        }

        public void AddEmployee(Employee employee)
        {
            _employeeManagementService.AddEmployee(employee);
        }

        public void ChangeSupervisor(Employee employee, Employee supervisor)
        {
            _employeeManagementService.ChangeSupervisor(employee, supervisor);
        }

        public IEnumerable<Employee> GetEmployeeHierarchy()
        {
            return _employeeManagementService.GetEmployeeHierarchy();
        }

        public IEnumerable<Task> IdTaskSearch(string id)
        {
            return _taskManagementService.IdTaskSearch(id);
        }

        public IEnumerable<Task> CreationTimeTaskSearch(DateTime creationTime)
        {
            return _taskManagementService.CreationTimeTaskSearch(creationTime);
        }

        public IEnumerable<Task> LastModifiedTaskSearch(DateTime lastModified)
        {
            return _taskManagementService.LastModifiedTaskSearch(lastModified);
        }

        public IEnumerable<Task> EmployeeTaskSearch(Employee employee)
        {
            return _taskManagementService.EmployeeTaskSearch(employee);
        }

        public IEnumerable<Task> SupervisorSubordinatesTasksSearch(Employee supervisor)
        {
            return _taskManagementService.SupervisorSubordinatesTasksSearch(supervisor);
        }

        public Task CreateTask(Task task)
        {
            return _taskManagementService.CreateTask(task);
        }

        public void EditTask(Task task)
        {
            _taskManagementService.EditTask(task);
        }

        public DailyReport CreateDailyReport(Employee employee)
        {
            return _reportManagementService.CreateDailyReport(employee);
        }

        public void EditDailyReport(DailyReport report)
        {
            _reportManagementService.EditDailyReport(report);
        }

        public void SaveDailyReport(DailyReport report)
        {
            _reportManagementService.SaveDailyReport(report);
        }

        public SprintReport CreateSprintReport(Employee employee)
        {
            return _reportManagementService.CreateSprintReport(employee);
        }

        public void EditSprintReport(SprintReport report)
        {
            _reportManagementService.EditSprintReport(report);
        }

        public void SaveSprintReport(SprintReport report)
        {
            _reportManagementService.SaveSprintReport(report);
        }

        public TeamReport CreateTeamReport(Employee employee)
        {
            return _reportManagementService.CreateTeamReport(employee);
        }

        public void EditTeamReport(TeamReport report)
        {
            _reportManagementService.EditTeamReport(report);
        }

        public void SaveTeamReport(TeamReport report)
        {
            _reportManagementService.SaveTeamReport(report);
        }
    }
}