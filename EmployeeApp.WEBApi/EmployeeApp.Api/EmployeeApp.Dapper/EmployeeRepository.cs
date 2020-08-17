using Dapper;
using EmployeeApp.Interfaces;
using EmployeeApp.Repository;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EmployeeApp.Dapper
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private IConfiguration _configuration;

        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
        public void Delete(int id)
        {
            var sql = "DELETE FROM employees WHERE id=@id";
            using(IDbConnection connection=new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                connection.Execute(sql,new { id });
                connection.Close();
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            var sql = "SELECT * FROM employees";
            using (IDbConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var rows=connection.Query<Employee>(sql);
                connection.Close();
                return rows;
            }
        }

        public Employee GetById(int id)
        {
            var sql = "SELECT * FROM employees WHERE id=@id";
            using (IDbConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var row = connection.Query<Employee>(sql,new { id }).SingleOrDefault();
                connection.Close();
                return row;
            }
        }

        public void Insert(Employee model)
        {
            var sql = "INSERT INTO employees(full_name,position,emp_code,mobile) VALUES(@FullName,@Position,@EmpCode,@Mobile)";
            using (IDbConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                connection.Execute(sql, model);
                connection.Close();
            }
        }

        public Employee Update(int id, Employee model)
        {
            var sql = "UPDATE employees SET full_name=@FullName,position=@Position,emp_code=@EmpCode,mobile=@Mobile WHERE id=@id";
            using (IDbConnection connection = new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                connection.Execute(sql, model);
                connection.Close();
                return model;
            }
        }
    }
}
