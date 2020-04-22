using System.Collections.Generic;
using System.Linq;

namespace Lab1.Models
{
    //[DataContract]
    public class Subjects
    {
        //[DataMember]
        public const string _name = "Average subject marks:";

        //[DataMember]
        public List<double> AverageSubjectMarks { get; set; } = new List<double>();

        //[DataMember]
        public string AverageMark { get; set; }

        public Subjects(IEnumerable<Student> students)
        {
            int countOfSubjects = students.First().Marks.Count();

            for (int i = 0;i < countOfSubjects;i++)
                AverageSubjectMarks.Add(students.Select(t => t.Marks[i]).Average());

            AverageMark = "Average academic performance: " + AverageSubjectMarks.Average();
        }
    }
}
