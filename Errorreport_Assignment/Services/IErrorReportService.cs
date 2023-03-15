using Errorreport_Assignment.MVVM.Model.Entitites;
using Errorreport_Assignment.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Errorreport_Assignment.Services
{
    public interface IErrorReportService 
    {
        IEnumerable<ErrorReportModel> GetAllErrorReports();
        ErrorReportModel GetErrorReportById(int id);
        void AddErrorReport(ErrorReportModel errorReport);
        void UpdateErrorReportStatus(int id, ErrorReportStatus status);
    }
}
