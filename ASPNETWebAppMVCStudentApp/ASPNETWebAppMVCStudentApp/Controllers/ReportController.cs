using ASPNETWebAppMVCStudentApp.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class ReportController : Controller
    {
        private SchoolDBEntities _context = new SchoolDBEntities();
        public ActionResult Index()
        {
            var model = new CourseViewModel
            {
                Courses = new SelectList(_context.Courses, "CourseID", "Title")
            };
            return View(model);
        }

        
        [HttpPost]
        public ActionResult Generate(int SelectedCourseID, string action)
        {
            
            var reportPath = Server.MapPath("~/Reports/StudentReport.rdlc");
            var localReport = new LocalReport { ReportPath = reportPath };

            var students = _context.Enrollments
                .Where(e => e.CourseID == SelectedCourseID) 
                .Select(e => new StudentReportDTO
                {
                    StudentID = e.Student.StudentID,
                    FirstName = e.Student.FirstName,
                    LastName = e.Student.LastName,
                    Grade = e.Grade
                }).ToList();

            localReport.DataSources.Add(new ReportDataSource("DataSetSinhVien", students));

            if (action == "export")
            {
                var reportBytes = localReport.Render("PDF");
                return File(reportBytes, "application/pdf", "StudentReport.pdf");
            }
            
            return RedirectToAction("Index");
        }
    }
}