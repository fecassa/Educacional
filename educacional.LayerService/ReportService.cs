using ClosedXML.Excel;
using educacional.LayerDomain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace educacional.LayerService
{
    public class ReportService
    {
        private readonly educacional.LayerInfrastructure.AppContext _context;
        private readonly string _reportPath;
        private string _userName;
        
        public ReportService(educacional.LayerInfrastructure.AppContext context, string reportPath)
        {
            _context = context;
            _reportPath = reportPath;
        }

        public string CreateReport(string userName)
        {            
            string _reportUrl = "";

            this._userName = userName;

            var _report = _context.Reports.FromSqlInterpolated<Report>($"exec STUDENREPORT").ToList<Report>();

            var _reportGenerated = this.GenerateReportXLSX(_report);

            _reportUrl = new System.Uri(_reportGenerated).AbsoluteUri;
            return _reportUrl;
        }

        private string GenerateReportXLSX(List<Report> data)
        {
            string _path = "";
            try
            {
                using var _workbook = new XLWorkbook();

                var _worksheet = _workbook.Worksheets.Add("Educacional Report");
                var _currentRow = 1;

                _worksheet.Cell(_currentRow, 1).Value = "Student";
                _worksheet.Cell(_currentRow, 2).Value = "Maths";
                _worksheet.Cell(_currentRow, 3).Value = "Portuguese";
                _worksheet.Cell(_currentRow, 4).Value = "History";
                _worksheet.Cell(_currentRow, 5).Value = "Geography";
                _worksheet.Cell(_currentRow, 6).Value = "English";
                _worksheet.Cell(_currentRow, 7).Value = "Biology";
                _worksheet.Cell(_currentRow, 8).Value = "Philosophy";
                _worksheet.Cell(_currentRow, 9).Value = "Physics";
                _worksheet.Cell(_currentRow, 10).Value = "Chemistry";
                _worksheet.Cell(_currentRow, 11).Value = "Average";

                foreach (Report row in data)
                {
                    _currentRow++;
                    _worksheet.Cell(_currentRow, 1).Value = row.Student;
                    _worksheet.Cell(_currentRow, 2).Value = row.Maths;
                    _worksheet.Cell(_currentRow, 3).Value = row.Portuguese;
                    _worksheet.Cell(_currentRow, 4).Value = row.History;
                    _worksheet.Cell(_currentRow, 5).Value = row.Geography;
                    _worksheet.Cell(_currentRow, 6).Value = row.English;
                    _worksheet.Cell(_currentRow, 7).Value = row.Biology;
                    _worksheet.Cell(_currentRow, 8).Value = row.Philosophy;
                    _worksheet.Cell(_currentRow, 9).Value = row.Physics;
                    _worksheet.Cell(_currentRow, 10).Value = row.Chemistry;
                    _worksheet.Cell(_currentRow, 11).Value = row.Average;
                }

                _path = this.GetPath();

                if (File.Exists(_path))
                {
                    File.Delete(_path);
                }

                using (FileStream _file = File.Create(_path))
                {
                    _workbook.SaveAs(_file);
                    _file.Close();
                }               
            }
            catch
            {
                //TODO LOG
            }
            return _path;
        }

        private string GetPath()
        {
            return String.Format(@"{0}Report_{1}.xlsx",this._reportPath, this._userName);
        }
    }
}
