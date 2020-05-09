using System.IO;
using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;
using Lab1.Services.Interfaces;
using Lab1.Models;

namespace Lab1.Services.IOSystem.Writers
{
    public class ExcelWriter : IWriter<Student>
    {
        public ExcelWriter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public void Write(IEnumerable<Student> collection, IEnumerable<string> fieldNames, string path)
        {
            using (ExcelPackage excel = new ExcelPackage())
            using (ExcelWorkbook workBook = excel.Workbook)
            using (ExcelWorksheet workSheet = workBook.Worksheets.Add(path))
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                int indexColumn = 1;
                int indexLine = 1;
                fieldNames.ToList().ForEach(column => workSheet.Cells[indexLine, indexColumn++].Value = column);
                foreach (Student student in collection)
                {
                    indexColumn = 1;
                    workSheet.Cells[indexLine, indexColumn++].Value = student.Surname;
                    workSheet.Cells[indexLine, indexColumn++].Value = student.Name;
                    workSheet.Cells[indexLine, indexColumn++].Value = student.MiddleName;
                    student.Marks.ForEach(mark => workSheet.Cells[indexLine, indexColumn++].Value = mark);
                    workSheet.Cells[indexLine, indexColumn].Value = student.AverageMark;
                    indexLine++;
                }
                Subjects AverageSubject = new Subjects(collection.ToList());
                workSheet.Cells[indexLine, 1].Value = Subjects.NAME;
                indexColumn = 4;
                AverageSubject.AverageSubjectMarks.ForEach(mark => workSheet.Cells[indexLine, indexColumn++].Value = mark);
                workSheet.Cells[indexLine, indexColumn].Value = AverageSubject.AverageMark;
                excel.SaveAs(fileStream);
            }
        }
    }
}
