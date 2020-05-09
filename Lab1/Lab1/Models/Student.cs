using System.Collections.Generic;
using System.Linq;

namespace Lab1.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public List<double> Marks { get; set; }
        public double AverageMark => Marks.Average();
    }
}
