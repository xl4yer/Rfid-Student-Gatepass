using Rfid.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Reporting.NETCore;
using Rfid.Services;
using System.Data;
using Rfid.Class;

namespace Rfid.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : Controller
    {
        StudentServices xservices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        IHubContext<Hub> _hub;

        public StudentController(StudentServices xservices, IWebHostEnvironment webHostEnvironment, IHubContext<Hub> hubContext)
        {
            
            this.xservices = xservices;
            _webHostEnvironment = webHostEnvironment;
            _hub = hubContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<students>> Students()
        {
            var ret = await xservices.Students();
            return ret;
        }

        [HttpPost]
        public async Task<int> AddStudent([FromBody] students xstud)
        {
            var ret = await xservices.AddStudent(xstud);
            return ret;
        }

        [HttpPut]
        public async Task<int> UpdateStudent([FromBody] students xstud)
        {
            var ret = await xservices.UpdateStudent(xstud);
            return ret;
        }

        [HttpGet]
        public async Task<List<students>> SearchStudent(string search)
        {
            var ret = await xservices.SearchStudent(search);
            return ret;
        }

        [HttpGet]
        public async Task<List<students>> SearchStudID(string search)
        {
            var ret = await xservices.SearchStudID(search);
            return ret;
        }

        [HttpGet]
        public async Task<int> CountStudents()
        {
            return await xservices.CountStudents();
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> StudentReport()
        {
            ListtoTable listtoTable = new();
            var dt = new DataTable();
            var lst = await xservices.Students();
            dt = listtoTable.ToDataTablee(lst);
            string reportPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "Students.rdlc");
            Stream reportDefinition;

            using var fs = new FileStream(reportPath, FileMode.Open);
            reportDefinition = fs;
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(reportDefinition);
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            byte[] excel = report.Render("EXCEL");
            fs.Dispose();

            return File(excel, "application/msexcel", "Students.xls");
        }
    }

}


