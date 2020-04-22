using Lab1.Services.Exceptions;
using Lab1.Models;
using System.Linq;

namespace Lab1.Services.Validation
{
    public static class ValidatorOfModels
    {
        public static void Validate(this Student student)
        {
            if (student.AverageMark < 0 || student.Marks.Any(t => t < 0))
                throw new MarkFieldException("Student has a wrong average mark or marks");
            else if (string.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.MiddleName) || string.IsNullOrEmpty(student.Surname))
                throw new FIOFieldException("Problem with FIO");
        }
        public static void Validate(this Subjects subjects)
        {
            if(subjects.AverageSubjectMarks.Any(t => t < 0))
                throw new MarkFieldException("Subjects has a wrong average mark or marks");
        }
        public static void Validate(this StudentInfo studentInfo)
        {
            if (studentInfo.AverageGrade < 0)
                throw new MarkFieldException("Student has a wrong average mark or marks");
            else if (string.IsNullOrEmpty(studentInfo.Name) || 
                string.IsNullOrEmpty(studentInfo.MiddleName) || string.IsNullOrEmpty(studentInfo.Surname))
                throw new FIOFieldException("Problem with FIO");
        }
    }
}
