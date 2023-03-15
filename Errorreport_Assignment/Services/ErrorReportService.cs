using Errorreport_Assignment.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Errorreport_Assignment.MVVM.Models;
using Errorreport_Assignment.MVVM.Model.Entitites;

namespace Errorreport_Assignment.Services
{
    public class ErrorReportService : IErrorReportService
    {
        private readonly IDataRepository<ErrorReportModel> _errorReportRepository;


        public ErrorReportService(IDataRepository<ErrorReportModel> errorReportRepository)
        {
            _errorReportRepository = errorReportRepository;
        }

        public void AddErrorReport(ErrorReportModel errorReport)
        {
            _errorReportRepository.Add(errorReport);
            _errorReportRepository.Save();
        }

        public IEnumerable<ErrorReportModel> GetAllErrorReports()
        {
            var errorReports = _errorReportRepository.GetAll();
            var mappedErrorReports = errorReports.Select(e => new ErrorReportModel
            {
                Id = e.Id,
                EntryTime = e.EntryTime,
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                EmailAddress = e.EmailAddress,
                Description = e.Description,
                Status = e.Status
            });
            return mappedErrorReports;
        }

        public ErrorReportModel GetErrorReportById(int id)
        {
            var errorReport = _errorReportRepository.GetById(id);

            if (errorReport == null)
            {
                throw new Exception($"Error report with id {id} was not found");
            }

            return errorReport;
        }

        public void UpdateErrorReportStatus(int id, ErrorReportStatus status)
        {
            var errorReport = _errorReportRepository.GetById(id);
            if (errorReport == null)
            {
                throw new Exception($"Error report with id {id} was not found");
            }
            errorReport.Status = status;
            _errorReportRepository.Update(errorReport);
            _errorReportRepository.Save();
        }
    }
}
