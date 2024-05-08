using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Reporting.NETCore;
using Rfid.Class;
using Rfid.Hubs;
using Rfid.Models;
using Rfid.Services;
using System.Data;

namespace Rfid.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttendanceController : Controller
    {
        AttendanceServices xservices;
        IHubContext<Hub> _hub;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AttendanceController(AttendanceServices xservices, IHubContext<Hub> hubContext, IWebHostEnvironment webHostEnvironment)
        {
            this.xservices = xservices;
            _hub = hubContext;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        //[Authorize]
        public async Task<List<attendance>> Attendance()
        {
            var ret = await xservices.Attendance();
            return ret;
        }

        [HttpGet]
        public async Task<List<attendance>> TAttendance()
        {
            var ret = await xservices.TAttendance();
            return ret;
        }

        [HttpGet]
        public async Task<List<attendance>> SearchAttendance(string search)
        {
            var ret = await xservices.SearchAttendance(search);
            return ret;
        }

        [HttpGet]
        public async Task<List<attendance>> SAttendanceDate(string search)
        {
            var ret = await xservices.SAttendanceDate(search);
            return ret;
        }

        [HttpGet]
        public async Task<List<attendance>> CheckTimeIN(string studID, DateTime timeIN)
        {
            var ret = await xservices.CheckTimeIN(studID, timeIN);
            return ret;
        }

        [HttpGet]
        public async Task<List<attendance>> CheckTimeOUT(string studID, DateTime timeOUT)
        {
            var ret = await xservices.CheckTimeOUT(studID, timeOUT);
            return ret;
        }

        [HttpGet]
        public async Task<List<attendance>> TimeIn()
        {
            var ret = await xservices.TimeIn();
            return ret;
        }

        [HttpGet]
        public async Task<List<attendance>> TimeOut()
        {
            var ret = await xservices.TimeOut();
            return ret;
        }

        [HttpPost]
        public async Task<int> AddAttendance([FromBody] attendance xattendance)
        {
            var ret = await xservices.AddAttendance(xattendance);
            return ret;
        }

        [HttpPut]
        public async Task<int> UpdateAttendance([FromBody] attendance xattendance)
        {
            var ret = await xservices.UpdateAttendance(xattendance);
            return ret;
        }

        [HttpGet]
        public async Task<int> CountTimeIn()
        {
            return await xservices.CountTimeIn();
        }

        [HttpGet]
        public async Task<int> InJanuary()
        {
            return await xservices.InJanuary();
        }
        [HttpGet]

        public async Task<int> InFebruary()
        {
            return await xservices.InFebruary();
        }
        [HttpGet]

        public async Task<int> InMarch()
        {
            return await xservices.InMarch();
        }
        [HttpGet]

        public async Task<int> InApril()
        {
            return await xservices.InApril();
        }
        [HttpGet]

        public async Task<int> InMay()
        {
            return await xservices.InMay();
        }
        [HttpGet]

        public async Task<int> InJune()
        {
            return await xservices.InJune();
        }
        [HttpGet]
        public async Task<int> InJuly()
        {
            return await xservices.InJuly();
        }
        [HttpGet]
        public async Task<int> InAugust()
        {
            return await xservices.InAugust();
        }
        [HttpGet]
        public async Task<int> InSeptember()
        {
            return await xservices.InSeptember();
        }
        [HttpGet]
        public async Task<int> InOctober()
        {
            return await xservices.InOctober();
        }
        [HttpGet]
        public async Task<int> InNovember()
        {
            return await xservices.InNovember();
        }
        [HttpGet]

        public async Task<int> InDecember()
        {
            return await xservices.InDecember();
        }
        [HttpGet]
        public async Task<int> OutJanuary()
        {
            return await xservices.OutJanuary();
        }
        [HttpGet]
        public async Task<int> OutFebruary()
        {
            return await xservices.OutFebruary();
        }

        [HttpGet]
        public async Task<int> OutMarch()
        {
            return await xservices.OutMarch();
        }

        [HttpGet]
        public async Task<int> OutApril()
        {
            return await xservices.OutApril();
        }

        [HttpGet]
        public async Task<int> OutMay()
        {
            return await xservices.OutMay();
        }

        [HttpGet]
        public async Task<int> OutJune()
        {
            return await xservices.OutJune();
        }


        [HttpGet]
        public async Task<int> OutJuly()
        {
            return await xservices.OutJuly();
        }

        [HttpGet]
        public async Task<int> OutAugust()
        {
            return await xservices.OutAugust();
        }


        [HttpGet]
        public async Task<int> OutSeptember()
        {
            return await xservices.OutSeptember();
        }

        [HttpGet]
        public async Task<int> OutOctober()
        {
            return await xservices.OutOctober();
        }

        [HttpGet]
        public async Task<int> OutNovember()
        {
            return await xservices.OutNovember();
        }

        [HttpGet]
        public async Task<int> OutDecember()
        {
            return await xservices.OutDecember();
        }

        [HttpGet]
        public async Task<int> CountTimeOut()
        {
            return await xservices.CountTimeOut();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AttendanceReport()
        {
            ListtoTable listtoTable = new();
            var dt = new DataTable();
            var lst = await xservices.Attendance();
            dt = listtoTable.ToDataTablee(lst);
            string reportPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Reports", "AttendanceReport.rdlc");
            Stream reportDefinition;

            using var fs = new FileStream(reportPath, FileMode.Open);
            reportDefinition = fs;
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(reportDefinition);
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            byte[] excel = report.Render("EXCEL");
            fs.Dispose();

            return File(excel, "application/msexcel", "Attendance.xls");
        }
    }
}
