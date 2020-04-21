using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab1.Services.Exceptions;
using Lab1.Models;
using Lab1.Services.Interfaces;
using Lab1.Services.Parsers;
using Lab1.Services.Validation;

namespace Lab1.Services.IOSystem.Readers
{
    public class CsvReader : IReader<Student>
    {
        public IEnumerable<Student> Read(string path, out List<string> fieldNames)
        {
            path.CsvPathValidation();
            path.CheckFileExistance();
            
            List<Student> students = new List<Student>();
            bool firstString = true;
            fieldNames = new List<string>();

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    string pattern = streamReader.ReadLine();

                    if (firstString)
                    {
                        fieldNames = pattern.Split(',', ';').ToList();
                        firstString = false;
                    }
                    else
                    {
                        if (pattern.Split(',', ';').Count() != fieldNames.Count)
                            throw new MarkFieldException("Incorrect count of marks");

                        Student student = pattern.ParseStudent();
                        student.Validate();
                        students.Add(student);
                    }
                }

              
            }

            return students;
        }
    }
}
