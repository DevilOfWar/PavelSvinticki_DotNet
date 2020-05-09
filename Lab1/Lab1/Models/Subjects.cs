using System.Collections.Generic;
using System.Linq;

namespace Lab1.Models
{
    public class Subjects
    {
        public const string NAME = "Average subject marks:";
        public List<double> AverageSubjectMarks { get; set; } = new List<double>();
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
