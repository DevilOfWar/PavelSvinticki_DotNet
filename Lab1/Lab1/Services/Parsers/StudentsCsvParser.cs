using System.Collections.Generic;
using System.Linq;
using Lab1.Models;

namespace Lab1.Services.Parsers
{
    public static class StudentsCsvParser
    {

        public static Student ParseStudent(this string pattern)
        {
            Student student = new Student();
            List<string> listOfValues = pattern.Split(',', ';').ToList();
            student.Surname = listOfValues[0];
            student.Name = listOfValues[1];
            student.MiddleName = listOfValues[2];
            student.Marks = listOfValues.Skip(3).Select(t => double.Parse(t)).ToList();
            return student;
        }

    }
}
