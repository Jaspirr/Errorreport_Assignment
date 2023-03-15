using Errorreport_Assignment.MVVM.Models;
using Errorreport_Assignment.Contexts;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Errorreport_Assignment.MVVM.Model.Entitites;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace Errorreport_Assignment.Services;

public class DataService
{
    private readonly string connectionString;

    public DataService(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<CustomerModel> GetCustomers()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection);

            SqlDataReader reader = command.ExecuteReader();

            List<CustomerModel> customers = new List<CustomerModel>();

            while (reader.Read())
            {
                CustomerModel customer = new CustomerModel
                {
                    CustomerId = reader.GetGuid(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    EmailAddress = reader.GetString(3),
                    PhoneNumber = reader.GetString(4)
                };

                customers.Add(customer);
            }

            return customers;
        }
    }

    public List<ErrorReportModel> GetErrorReports()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM ErrorReports", connection);

            SqlDataReader reader = command.ExecuteReader();

            List<ErrorReportModel> errorReports = new List<ErrorReportModel>();

            while (reader.Read())
            {
                ErrorReportModel errorReport = new ErrorReportModel
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    EntryTime = reader.GetDateTime(2),
                    Status = reader.GetString(3),
                    CustomerId = reader.GetGuid(4)
                };

                errorReports.Add(errorReport);
            }

            return errorReports;
        }
    }


    public List<CommentModel> GetComments(Guid errorReportId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Comments WHERE ErrorReportId = @ErrorReportId", connection);
            command.Parameters.AddWithValue("@ErrorReportId", errorReportId);

            SqlDataReader reader = command.ExecuteReader();

            List<CommentModel> comments = new List<CommentModel>();

            while (reader.Read())
            {
                CommentModel comment = new CommentModel  
                {
                    Id = reader.GetInt32(0),
                    CommentString = reader.GetString(1),
                    EntryTime = reader.GetDateTime(2),
                    ErrorReportId = reader.GetInt32(3)
                };

                comments.Add(comment);
            }

            return comments;
        }
    }

    public void UpdateErrorReportStatus(Guid errorReportId, string status)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE ErrorReports SET Status = @Status WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Status", status);
            command.Parameters.AddWithValue("@Id", errorReportId);

            command.ExecuteNonQuery();
        }
    }
}

