using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETWebAppMVCStudentApp.Models
{
    public class StudentReportDTO
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Grade { get; set; }
    }
}