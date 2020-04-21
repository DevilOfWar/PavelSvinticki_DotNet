using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Linq;
using Lab1.Models;
using Lab1.Services.Interfaces;

namespace Lab1.Services.IOSystem.Writers
{
    public class JsonWriter : IWriter<Student>
    {
        public void Write(IEnumerable<Student> collection, IEnumerable<string> fieldNames, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                List<StudentInfo> studentInfos = collection.Select(t => new StudentInfo()
                {
                    Name = t.Name,
                    MiddleName = t.MiddleName,
                    Surname = t.Surname,
                    AverageGrade = t.AverageMark
                }).ToList();

                DataContractJsonSerializer serializerStudent = new DataContractJsonSerializer(typeof(List<StudentInfo>));
                serializerStudent.WriteObject(stream, studentInfos);
                DataContractJsonSerializer serializerSubjects = new DataContractJsonSerializer(typeof(Subjects));
                serializerSubjects.WriteObject(stream, new Subjects(collection));
            }
        }
    }
}
