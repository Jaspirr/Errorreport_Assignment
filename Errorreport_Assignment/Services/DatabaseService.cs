using Errorreport_Assignment.MVVM.Models;
using Errorreport_Assignment.Contexts;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Errorreport_Assignment.MVVM.Model.Entitites;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace Errorreport_Assignment.Services;

internal class DatabaseService
{
    public static DataContext _context = new DataContext();

    public static async Task SaveToDbAsync(ErrorReportModel newErrorReport)
    {
        CustomerEntity customerEntity = newErrorReport;
        ErrorReportEntity errorReportEntity = newErrorReport;
        CustomerEntity _currentCustomer = null!;
        WorkerEntity workerEntity = null!;
        //Checks if there is any customer in the db with the entered email already
        var _allCustomers = await _context.Customers.ToListAsync();
        var customerNotUniqueEmail = _allCustomers.Where(x => x.EmailAddress == customerEntity.EmailAddress);

        foreach (var customer in customerNotUniqueEmail)
        {
            _currentCustomer = new CustomerEntity()
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                EmailAddress = customer.EmailAddress,
                PhoneNumber = customer.PhoneNumber
            };
        }

        if (customerNotUniqueEmail.IsNullOrEmpty())
        {
            _context.Add(customerEntity);
            errorReportEntity.CustomerId = customerEntity.CustomerId;
            _context.Add(errorReportEntity);
            await _context.SaveChangesAsync();
        }
        else
        {
            //If email is not unique in the db, it sets the newCase to the customer with the matching email in db.
            errorReportEntity.CustomerId = _currentCustomer.CustomerId;
            _context.Add(errorReportEntity);
            await _context.SaveChangesAsync();
        }
    }

    public static async Task<ObservableCollection<ErrorReportModel>> GetAllFromDbAsync()
    {
        var _errorReports = new ObservableCollection<ErrorReportModel>();

        foreach (var _errorReport in await _context.ErrorReports.Include(x => x.Customer).ToListAsync())
        {
            CustomerEntity customerEntity = _errorReport.Customer;
            ErrorReportEntity errorReportEntity = _errorReport;

            _errorReports.Add(new ErrorReportModel
            {
                ErrorReportId = errorReportEntity.ErrorReportId,
                Description = errorReportEntity.Description,
                EntryTime = errorReportEntity.EntryTime,
                Status = errorReportEntity.Status,
                CustomerFirstName = customerEntity.FirstName,
                CustomerLastName = customerEntity.LastName,
                CustomerEmailAddress = customerEntity.EmailAddress,
                CustomerPhoneNumber = customerEntity.PhoneNumber
            });
        }

        return _errorReports;
    }

    public static async Task<ObservableCollection<WorkerModel>> GetAllWorkersAsync()
    {
        var _workers = new ObservableCollection<WorkerModel>();

        foreach (var _worker in await _context.Workers.ToListAsync())
        {
            WorkerEntity workerEntity = _worker;

            _workers.Add(new WorkerModel
            {
                Id = WorkerEntity.WorkerId,
                FirstName = WorkerEntity.FirstName,
                LastName = WorkerEntity.LastName,
                NameInitials = WorkerEntity.NameInitials
            });
        }

        return _workers;
    }


    public static async Task<ObservableCollection<CommentModel>> GetSpecificCommentsFromDbAsync(ErrorReportModel currentErrorReport)
    {
        var _allComments = new ObservableCollection<CommentEntity>();
        var _actualComments = new ObservableCollection<CommentModel>();
        var _currentErrorReportId = currentErrorReport.ErrorReportId;

        foreach (var _comment in await _context.Comments.ToListAsync())
        {
            _allComments.Add(_comment);
        };

        foreach (var _actualComment in _allComments.Where(x => x.ErrorReportId == _currentErrorReportId))
        {
            CommentModel _comment = _actualComment;
            _actualComments.Add(_comment);
        }

        return _actualComments;
    }

    public static async Task ChangeStatusAsync(ErrorReportModel currentErrorReport)
    {
        var _dbErrorReportEntity = await _context.ErrorReports.FirstOrDefaultAsync(x => x.ErrorReportId == currentErrorReport.ErrorReportId);

        _dbErrorReportEntity!.Status = currentErrorReport.Status;

        _context.Update(_dbErrorReportEntity);
        await _context.SaveChangesAsync();
    }

    public static async Task SaveCommentToDbAsync(CommentModel comment, int errorReportId)
    {
        CommentEntity commentEntity = comment;
        commentEntity.ErrorReportId = errorReportId;
        _context.Add(commentEntity);
        await _context.SaveChangesAsync();
    }

    public static async Task RemoveErrorReportAsync(ErrorReportModel clickedErrorReport)
    {
        var _dbErrorReportEntity = await _context.ErrorReports.FirstOrDefaultAsync(x => x.ErrorReportId == clickedErrorReport.ErrorReportId);

        if (_dbErrorReportEntity != null)
        {
            var _allComments = new List<CommentEntity>();

            foreach (var _comment in await _context.Comments.ToListAsync())
            {
                _allComments.Add(_comment);
            };

            foreach (var _associatedComment in _allComments.Where(x => x.ErrorReportId == _dbErrorReportEntity.ErrorReportId))
            {
                _context.Remove(_associatedComment);
            }

            _context.Remove(_dbErrorReportEntity);
            await _context.SaveChangesAsync();
        }
    }
}

