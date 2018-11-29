using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MyServer.Models
{
    public class employeeDataAccessLayer
    {
        // string connectionString = "Data Source=\SQLEXPRESS;Initial Catalog=travelstart;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        //To View all employees details
        /*  public IEnumerable<tblEmployee> GetAllEmployees()
          {
              try
              {
                  List<tblEmployee> lstemployee = new List<tblEmployee>();
                  using (SqlConnection con = new SqlConnection(connectionString))
                  {
                      SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                      cmd.CommandType = CommandType.StoredProcedure;
                      con.Open();
                      SqlDataReader rdr = cmd.ExecuteReader();
                      while (rdr.Read())
                      {
                          tblEmployee employee = new tblEmployee();
                          employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                          employee.Name = rdr["Name"].ToString();
                          employee.Gender = rdr["Gender"].ToString();
                          employee.Department = rdr["Department"].ToString();
                          employee.City = rdr["City"].ToString();
                          lstemployee.Add(employee);
                      }
                      con.Close();
                  }
                  return lstemployee;
              }
              catch
              {
                  throw;
              }
          }
          //To Add new employee record 
          public int AddEmployee(tblEmployee employee)
          {
              try
              {
                  using (SqlConnection con = new SqlConnection(connectionString))
                  {
                      SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@Name", employee.Name);
                      cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                      cmd.Parameters.AddWithValue("@Department", employee.Department);
                      cmd.Parameters.AddWithValue("@City", employee.City);
                      con.Open();
                      cmd.ExecuteNonQuery();
                      con.Close();
                  }
                  return 1;
              }
              catch
              {
                  throw;
              }
          }
          //To Update the records of a particluar employee
          public int UpdateEmployee(tblEmployee employee)
          {
              try
              {
                  using (SqlConnection con = new SqlConnection(connectionString))
                  {
                      SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@EmpId", employee.EmployeeId);
                      cmd.Parameters.AddWithValue("@Name", employee.Name);
                      cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                      cmd.Parameters.AddWithValue("@Department", employee.Department);
                      cmd.Parameters.AddWithValue("@City", employee.City);
                      con.Open();
                      cmd.ExecuteNonQuery();
                      con.Close();
                  }
                  return 1;
              }
              catch
              {
                  throw;
              }
          }
          //Get the details of a particular employee
          public tblEmployee GetEmployeeData(int id)
          {
              try
              {
                  tblEmployee employee = new tblEmployee();
                  using (SqlConnection con = new SqlConnection(connectionString))
                  {
                      string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                      SqlCommand cmd = new SqlCommand(sqlQuery, con);
                      con.Open();
                      SqlDataReader rdr = cmd.ExecuteReader();
                      while (rdr.Read())
                      {
                          employee.EmployeeId = Convert.ToInt32(rdr["EmployeeID"]);
                          employee.Name = rdr["Name"].ToString();
                          employee.Gender = rdr["Gender"].ToString();
                          employee.Department = rdr["Department"].ToString();
                          employee.City = rdr["City"].ToString();
                      }
                  }
                  return employee;
              }
              catch
              {
                  throw;
              }
          }
          //To Delete the record on a particular employee
          public int DeleteEmployee(int id)
          {
              try
              {
                  using (SqlConnection con = new SqlConnection(connectionString))
                  {
                      SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.AddWithValue("@EmpId", id);
                      con.Open();
                      cmd.ExecuteNonQuery();
                      con.Close();
                  }
                  return 1;
              }
              catch
              {
                  throw;
              }
          }

      }*/
    }
}