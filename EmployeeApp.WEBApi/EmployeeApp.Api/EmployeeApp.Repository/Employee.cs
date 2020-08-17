using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeApp.Repository
{
    [Table("employees")]
    public class Employee
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("position")]
        public string Position { get; set; }
        [Column("emp_code")]
        public string EMPCode { get; set; }
        [Column("mobile")]
        public string Mobile { get; set; }
    }
}
