using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Models
{
    //[DataContract]
    public class StudentInfo
    {
        //[DataMember]
        public string Name { get; set; }

        //[DataMember]
        public string Surname { get; set; }

        //[DataMember]
        public string MiddleName { get; set; }

        //[DataMember]
        public double AverageGrade { get; set; }

    }
}
